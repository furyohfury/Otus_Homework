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

			RaiseEoTEvents(currentHero);	
			SetVisualInactive(currentHero);
			Finish();
		}

		private void RaiseEoTEvents(HeroEntity hero)
		{
			if (currentHero.TryGetData(out EndOfTurnComponent endOfTurnComponent))
			{
				foreach (var endOfTurnEvent in endOfTurnComponent.Events)
				{
					endOfTurnEvent.Source = currentHero;
					_eventBus.RaiseEvent(endOfTurnEvent);
				}
			}
		}

		private void SetVisualInactive(HeroEntity hero)
		{
			heroViewComponent = currentHero.GetData<HeroViewComponent>();
			heroViewComponent.HeroView.SetActive(false);
		}
	}
}