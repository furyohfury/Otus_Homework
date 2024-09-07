using System.Collections.Generic;
using System.Linq;
using Entities;
using UI;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private readonly TurnPipeline[] _pipelines;
		private int _activeIndex;

		private HeroEntity[] _heroEntities;
		private CurrentHeroService _currentHeroService;
		private UIService _uiService;
		private readonly LinkedList<HeroEntity> _heroEntitiesOrder = new();
		private LinkedListNode<HeroEntity> _currentHeroNode;

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines, CurrentHeroService currentHeroService,
			HeroEntity[] heroEntities, UIService uiService)
		{
			_pipelines = pipelines;
			_currentHeroService = currentHeroService;
			_heroEntities = heroEntities;
			_uiService = uiService;
		}

		void IInitializable.Initialize()
		{
			for (var i = 0; i < _pipelines.Length; i++)
			{
				_pipelines[i].OnFinished += OnFinished;
			}

			InitializeOrder();
			_currentHeroNode = _heroEntitiesOrder.First;
			_currentHeroService.SetCurrentHero(_currentHeroNode.Value);
			Run();
		}

		private void OnFinished()
		{
			_pipelines[_activeIndex].Reset();
			_activeIndex = _activeIndex == _pipelines.Length - 1 ? 0 : _activeIndex + 1;

			_currentHeroNode = _currentHeroNode.Next ?? _heroEntitiesOrder.First;
			_currentHeroService.SetCurrentHero(_currentHeroNode.Value);
			Run();
		}

		public void Run()
		{
			_pipelines[_activeIndex].RunNextTask();
		}

		private void InitializeOrder()
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
			                                   .ToArray();

			var playerTwoHeroes = _heroEntities.Except(playerOneHeroes)
			                                   .OrderBy(entity =>
			                                   {
				                                   entity.TryGetData(out HeroViewComponent heroViewComponent);
				                                   var heroView = heroViewComponent.HeroView;
				                                   return heroView.transform.position.x;
			                                   })
			                                   .ToArray();

			for (var i = 0; i < playerOneHeroes.Length; i++)
			{
				_heroEntitiesOrder.AddLast(playerOneHeroes[i]);
				_heroEntitiesOrder.AddLast(playerTwoHeroes[i]);
			}

			foreach (var heroEntity in _heroEntitiesOrder)
			{
				if (!heroEntity.TryGetData(out DestroyComponent destroyComponent)) return;

				destroyComponent.OnDestroyed += () =>
				{
					if (_currentHeroNode.Value == heroEntity)
					{
						_currentHeroNode = _currentHeroNode.Next ?? _heroEntitiesOrder.First; // TODO fix if next is first (mb while cycle)
					}
					_heroEntitiesOrder.Remove(heroEntity);
				};
			}
		}
	}
}