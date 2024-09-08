using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private readonly TurnPipeline[] _pipelines;
		private int _activeIndex;

		private readonly HeroEntity[] _heroEntities;
		private readonly CurrentHeroService _currentHeroService;
		private Player _currentPlayer = Player.One;
		private LinkedList<HeroEntity> _playerOneHeroes;
		private LinkedListNode<HeroEntity> _playerOneHeroNode;
		private LinkedList<HeroEntity> _playerTwoHeroes;
		private LinkedListNode<HeroEntity> _playerTwoHeroNode;

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			HeroEntity[] heroEntities)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_heroEntities = heroEntities;
		}

		void IInitializable.Initialize()
		{
			for (var i = 0; i < _pipelines.Length; i++)
			{
				_pipelines[i].OnFinished += OnFinished;
			}

			InitializeOrder();
			Run();
		}

		private void OnFinished()
		{
			_pipelines[_activeIndex].Reset();
			_activeIndex = _activeIndex == _pipelines.Length - 1 ? 0 : _activeIndex + 1;
			ChangeCurrentHero();
			Run();
		}

		public void Run()
		{
			_pipelines[_activeIndex].RunNextTask();
		}

		private void InitializeOrder() // TODO full cringe redo
		{
			var playerOneHeroes = _heroEntities.Where(entity =>
			                                {
				                                entity.TryGetData(out TeamComponent teamComponent);
				                                return teamComponent.Team == Team.Blue;
			                                })
			                                .OrderBy(entity =>
			                                {
				                                entity.TryGetData(out HeroViewComponent heroViewComponent);
				                                var heroView = heroViewComponent.HeroView;
				                                return heroView.transform.position.x;
			                                })
			                                .ToList();
			_playerOneHeroes = new LinkedList<HeroEntity>(playerOneHeroes);

			var playerTwoHeroes = _heroEntities.Except(_playerOneHeroes)
			                                .OrderBy(entity =>
			                                {
				                                entity.TryGetData(out HeroViewComponent heroViewComponent);
				                                var heroView = heroViewComponent.HeroView;
				                                return heroView.transform.position.x;
			                                })
			                                .ToArray();
			_playerTwoHeroes = new LinkedList<HeroEntity>(playerTwoHeroes);
			
			_playerOneHeroNode = _playerOneHeroes.First;
			_playerTwoHeroNode = _playerTwoHeroes.Last;

			foreach (var playerOneHero in _playerOneHeroes) // TODO fix if current hero destroyed
			{
				if (playerOneHero.TryGetData(out DestroyComponent destroyComponent))
				{
					destroyComponent.OnDestroyed += () =>
					{
						_playerOneHeroes.Remove(playerOneHero);
					};
				}
			}
			
			foreach (var playerTwoHero in _playerTwoHeroes)
			{
				if (playerTwoHero.TryGetData(out DestroyComponent destroyComponent))
				{
					destroyComponent.OnDestroyed += () =>
					{
						_playerTwoHeroes.Remove(playerTwoHero);
					};
				}
			}
			
			_currentHeroService.SetCurrentHero(_playerOneHeroes.First.Value);
		}
		
		private void ChangeCurrentHero()
		{
			if (_currentPlayer == Player.One)
			{
				if (_playerTwoHeroes.Count <= 0)
				{
					Debug.Log("Player two has no heroes left");
					EditorApplication.isPaused = true;
				}
				_currentPlayer = Player.Two;
				var currentHero = _playerTwoHeroNode.Next ?? _playerTwoHeroes.First;
				_playerTwoHeroNode = currentHero;
				_currentHeroService.SetCurrentHero(currentHero.Value);
			}
			else
			{
				if (_playerOneHeroes.Count <= 0)
				{
					Debug.Log("Player one has no heroes left");
					EditorApplication.isPaused = true;
				}
				_currentPlayer = Player.One;
				var currentHero = _playerOneHeroNode.Next ?? _playerOneHeroes.First;
				_playerOneHeroNode = currentHero;
				_currentHeroService.SetCurrentHero(currentHero.Value);
			}
			Debug.Log($"Changed current hero, now is {_currentHeroService.CurrentHero.gameObject.name}");
		}
		
		private enum Player : byte
		{
			One,
			Two
		}
	}
}