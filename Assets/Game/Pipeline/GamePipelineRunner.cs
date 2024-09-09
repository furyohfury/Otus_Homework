using System.Collections.Generic;
using Entities;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private readonly TurnPipeline[] _pipelines;
		private int _activeIndex;

		private readonly CurrentHeroService _currentHeroService;
		private Player _currentPlayer = Player.One;
		private readonly Dictionary<Player, HeroCollection> _heroCollections = new();

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			HeroEntity[] playerOneHeroes, HeroEntity[] playerTwoHeroes)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_heroCollections.Add(Player.One, new HeroCollection(playerOneHeroes, 0));
			_heroCollections.Add(Player.Two, new HeroCollection(playerTwoHeroes, playerTwoHeroes.Length - 1));
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
			_activeIndex = _activeIndex == _pipelines.Length - 1
				? 0
				: _activeIndex + 1;
			ChangeCurrentHero();
			Run();
		}

		public void Run()
		{
			_pipelines[_activeIndex].RunNextTask();
		}

		private void InitializeOrder()
		{
			foreach (var playerOneHero in _heroCollections[Player.One].HeroEntities)
			{
				playerOneHero.TryGetData(out DestroyComponent destroyComponent);
				destroyComponent.OnDestroyed += () => _heroCollections[Player.One].RemoveHero(playerOneHero);
			}

			foreach (var playerTwoHero in _heroCollections[Player.Two].HeroEntities)
			{
				playerTwoHero.TryGetData(out DestroyComponent destroyComponent);
				destroyComponent.OnDestroyed += () => _heroCollections[Player.Two].RemoveHero(playerTwoHero);
			}

			_currentHeroService.SetCurrentHero(_heroCollections[Player.One].HeroEntities[0]);
		}

		private void ChangeCurrentHero()
		{
			_currentPlayer = _currentPlayer == Player.One
				? Player.Two
				: Player.One;
			if (!_heroCollections[_currentPlayer].TryGetNextHero(out var nextHero))
			{
				// TODO game over logic here or in separate controller
			}

			_currentHeroService.SetCurrentHero(nextHero);
		}
	}
}