using Entities;
using UI;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public class PlayerInputTask : EventTask
	{
		private EventBus _eventBus;
		private HeroListView _enemyHeroListView;
		private CurrentHeroService _currentHeroService;

		[Inject]
		public void Construct(EventBus eventBus, UIService uiservice, CurrentHeroService currentHeroService)
		{
			_eventBus = eventBus;
			_enemyHeroListView = uiservice.GetRedPlayer();
			_currentHeroService = currentHeroService;
		}

		protected override void OnRun()
		{
			Debug.Log("PlayerInputTask OnRun");
			_enemyHeroListView.OnHeroClicked += OnHeroClicked;
		}

		protected override void OnFinish()
		{
			_enemyHeroListView.OnHeroClicked -= OnHeroClicked;
		}

		private void OnHeroClicked(HeroView hero)
		{
			Debug.Log($"Clicked hero {hero.name}");
			var currentHero = _currentHeroService.CurrentHero;

			if (currentHero.HasData<FrozenComponent>())
			{
				_eventBus.RaiseEvent(new RemoveFrozenEvent(currentHero));
			}
			else if (currentHero.TryGetData(out AttackWrongTargetComponent attackWrongTargetComponent))
			{
				_eventBus.RaiseEvent(new AttackWrongTargetEvent(attackWrongTargetComponent.Probability,
					hero.GetComponent<HeroEntity>()));
			}
			else
			{
				_eventBus.RaiseEvent(new AttackEvent(currentHero,
					hero.GetComponent<HeroEntity>()));
			}

			Finish();
		}
	}
}