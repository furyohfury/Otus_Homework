using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class EndOfTurnTask : EventTask
	{
		private readonly CurrentHeroService _currentHeroService;
		private readonly EventBus _eventBus;
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

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

			RaiseEoTHeroEvents(currentHero);	
			RaiseEoTPlayerEvents(currentHero);
			RaiseEoTEnemyEvents();
			SetVisualInactive(currentHero);			
			Finish();
		}

		private void RaiseEoTHeroEvents(HeroEntity hero)
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

		private void RaiseEoTPlayerEvents()
		{
			var currentPlayer = _currentHeroService.CurrentPlayer;
			var currentPlayerHeroes = _heroCollections[currentPlayer].HeroEntities;
			foreach (var hero in currentPlayerHeroes)
			{
				if (hero == currentHero) continue;

				if (!hero.TryGetData(out EndOfTurnComponent endOfTurnComponent)) continue;
				
				foreach (var endOfTurnEvent in endOfTurnComponent.Events)
				{
					if (endOfTurnEvent.EventTriggerLink == EventTriggerLink.Player)
					{
						endOfTurnEvent.Source = hero;
						_eventBus.RaiseEvent(endOfTurnEvent);
					}
				}				
			}
		}

		private void RaiseEoTEnemyEvents(HeroEntity currentHero)
		{
			var enemyPlayer = _currentHeroService.CurrentPlayer == Player.Blue 
				? Player.Red
				: Player.Blue; 
			var enemyPlayerHeroes = _heroCollections[enemyPlayer].HeroEntities;

			foreach (var hero in enemyPlayerHeroes)
			{
				if (!hero.TryGetData(out EndOfTurnComponent endOfTurnComponent)) continue;
				
				foreach (var endOfTurnEvent in endOfTurnComponent.Events)
				{
					if (endOfTurnEvent.EventTriggerLink == EventTriggerLink.Any)
					{
						endOfTurnEvent.Source = hero;
						_eventBus.RaiseEvent(endOfTurnEvent);
					}
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