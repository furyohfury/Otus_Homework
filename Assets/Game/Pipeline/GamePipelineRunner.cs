using System.Collections.Generic;
using Entities;
using Zenject;

namespace EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private readonly TurnPipeline[] _pipelines;
		private int _activeIndex;

		private readonly CurrentHeroService _currentHeroService;
		private Player _currentPlayer = Player.Blue; // TODO in currentHeroService
		private readonly Dictionary<Player, HeroCollection> _heroCollections = new();

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			HeroEntity[] playerOneHeroes, HeroEntity[] playerTwoHeroes)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_heroCollections.Add(Player.Blue, new HeroCollection(playerOneHeroes, 0));
			_heroCollections.Add(Player.Red, new HeroCollection(playerTwoHeroes, playerTwoHeroes.Length - 1));
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
			foreach (var playerBlueHero in _heroCollections[Player.Blue].HeroEntities)
			{
				playerBlueHero.TryGetData(out DestroyComponent destroyComponent);
				destroyComponent.OnDestroyed += () => _heroCollections[Player.Blue].RemoveHero(playerBlueHero);
			}

			foreach (var playerRedHero in _heroCollections[Player.Red].HeroEntities)
			{
				playerRedHero.TryGetData(out DestroyComponent destroyComponent);
				destroyComponent.OnDestroyed += () => _heroCollections[Player.Red].RemoveHero(playerRedHero);
			}

			_currentHeroService.SetCurrentHero(_heroCollections[Player.Blue].HeroEntities[0]);
		}

		private void ChangeCurrentHero()
		{
			_currentPlayer = _currentPlayer == Player.Blue
				? Player.Red
				: Player.Blue;
			if (!_heroCollections[_currentPlayer].TryGetNextHero(out var nextHero))
			{
				// TODO game over logic here or in separate controller
			}

			_currentHeroService.SetCurrentHero(nextHero);
		}
	}
}