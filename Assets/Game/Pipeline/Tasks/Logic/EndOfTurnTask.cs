using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class EndOfTurnTask : EventTask // TODO works before destroyed
	{
		private readonly CurrentHeroService _currentHeroService;
		private readonly EventBus _eventBus;
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

		[Inject]
		public EndOfTurnTask(CurrentHeroService currentHeroService, EventBus eventBus,
			Dictionary<Player, HeroCollection> heroCollections)
		{
			_currentHeroService = currentHeroService;
			_eventBus = eventBus;
			_heroCollections = heroCollections;
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

		private void RaiseEoTHeroEvents(HeroEntity currentHero)
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

		private void RaiseEoTPlayerEvents(HeroEntity currentHero)
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

		private void RaiseEoTEnemyEvents()
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

		private void SetVisualInactive(HeroEntity currentHero)
		{
			var heroViewComponent = currentHero.GetData<HeroViewComponent>();
			heroViewComponent.HeroView.SetActive(false);
		}
	}
}