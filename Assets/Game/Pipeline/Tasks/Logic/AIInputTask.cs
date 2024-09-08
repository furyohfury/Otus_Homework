using System.Linq;
using Entities;
using UI;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Lessons.Lesson19_EventBus
{
	public class AIInputTask : EventTask
	{
		private readonly EventBus _eventBus;
		private readonly HeroListView _playerHeroListView;
		private readonly CurrentHeroService _currentHeroService;

		[Inject]
		public AIInputTask(EventBus eventBus, UIService uiservice, CurrentHeroService currentHeroService)
		{
			_eventBus = eventBus;
			_playerHeroListView = uiservice.GetBluePlayer();
			_currentHeroService = currentHeroService;
		}

		protected override void OnRun()
		{
			Debug.Log("AI input task OnRun");
			// TODO if frozen
			// if (_currentHeroService.CurrentHero.TryGetData<Disabled>(out _))
			// {
			//     Finish();
			//     return;
			// }
			var currentHero = _currentHeroService.CurrentHero;

			var playerHeroViews = _playerHeroListView.GetViews();
			var activePlayerHeroView = playerHeroViews.Where(view => view.isActiveAndEnabled).ToArray();

			if (!activePlayerHeroView.Any())
			{
				Debug.Log("No targets");
				return;
			}

			var index = Random.Range(0, activePlayerHeroView.Length);
			var hero = activePlayerHeroView[index];

			_eventBus.RaiseEvent(new AttackEvent(currentHero, hero.GetComponent<HeroEntity>()));
			Finish();
		}
	}
}