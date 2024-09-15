using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class EndOfTurnTask : EventTask
	{
		private readonly CurrentHeroService _currentHeroService;
		private readonly EventBus _eventBus;

		[Inject]
		public EndOfTurnTask(CurrentHeroService currentHeroService, EventBus eventBus)
		{
			_currentHeroService = currentHeroService;
			_eventBus = eventBus;
		}

		protected override void OnRun()
		{
			Debug.Log("EndOfTurnTask OnRun");
			var currentHero = _currentHeroService.CurrentHero;

			if (currentHero.TryGetData(out EndOfTurnComponent endOfTurnComponent))
			{
				foreach (var endOfTurnEvent in endOfTurnComponent.Events)
				{
					endOfTurnEvent.Source = currentHero;
					_eventBus.RaiseEvent(endOfTurnEvent);
				}
			}

			currentHero.TryGetData(out HeroViewComponent heroViewComponent);
			heroViewComponent.HeroView.SetActive(false);
			Finish();
		}
	}
}