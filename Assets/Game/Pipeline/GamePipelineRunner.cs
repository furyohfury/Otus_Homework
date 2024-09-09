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

		private readonly CurrentHeroService _currentHeroService;
		private Player _currentPlayer = Player.One;
		private LinkedList<HeroEntity> _playerOneHeroes;
		private LinkedListNode<HeroEntity> _playerOneHeroNode;
		private LinkedList<HeroEntity> _playerTwoHeroes;
		private LinkedListNode<HeroEntity> _playerTwoHeroNode;

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			HeroEntity[] playerOneHeroes, HeroEntity[] playerTwoHeroes)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_playerOneHeroes = new LinkedList<HeroEntity>(playerOneHeroes);
			_playerTwoHeroes = new LinkedList<HeroEntity>(playerTwoHeroes);
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

		private void InitializeOrder() // TODO full cringe redo (soso)
		{			
			_playerOneHeroNode = _playerOneHeroes.First;
			_playerTwoHeroNode = _playerTwoHeroes.Last;

			foreach (var playerOneHero in _playerOneHeroes) // TODO fix if current hero destroyed
			{
				playerOneHero.TryGetData(out DestroyComponent destroyComponent)
				
					destroyComponent.OnDestroyed += () =>
					{
						_playerOneHeroes.Remove(playerOneHero);
					};
				
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
			_currentPlayer = _currentPlayer == Player.One ? PlayerTwo : PlayerOne;
			if (!TryGetNextHero(_currentPlayer, out HeroEntity nextHero))
			{
				Debug.Log($"{_currentPlayer.ToString()} has no heroes left");
				EditorApplication.isPaused = true;
			}

			_currentHeroService.SetCurrentHero(nextHero);
		}

		private bool TryGetNextHero(Player player, out HeroEntity nextHero)
		{
			if (player == Player.One)
			{
				if (_playerOneHeroes.Count <= 0)
				{
					nextHero = default;
					return false;
				}
				nextHero = _playerOneHeroNode.Next ?? _playerOneHeroes.First;
				_playerOneHeroNode = nextHero;
				return true;
			}
			else
			{
				if (_playerTwoHeroes.Count <= 0)
				{
					nextHero = default;
					return false;
				}
				nextHero = _playerTwoHeroNode.Next ?? _playerTwoHeroes.First;
				_playerTwoHeroNode = nextHero;
				return true;
			}
		}
		
		public enum Player : byte
		{
			One,
			Two
		}
	}
}