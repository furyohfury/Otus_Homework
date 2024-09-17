using System.Collections.Generic;
using Entities;
using EventBus;
using Zenject;

namespace Game.EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private readonly TurnPipeline[] _pipelines;
		private int _activeIndex;

		private readonly CurrentHeroService _currentHeroService;
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			Dictionary<Player, HeroCollection> heroCollections)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_heroCollections = heroCollections;
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
			var currentPlayer = _currentHeroService.CurrentPlayer == Player.Blue
				? Player.Red
				: Player.Blue;
			_currentHeroService.SetCurrentPlayer(currentPlayer);
			if (!_heroCollections[currentPlayer].TryGetNextHero(out var nextHero))
			{
				// TODO game over logic here or in separate controller
			}

			_currentHeroService.SetCurrentHero(nextHero);
		}
	}
}