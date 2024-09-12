using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Entities;
using UI;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace EventBus
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

		protected override async void OnRun()
		{
			Debug.Log("AI input task OnRun");			

			await UniTask.Delay(TimeSpan.FromSeconds(1));

			if (currentHero.HasData<FrozenComponent>())
            {
                 _eventBus.RaiseEvent(new RemoveFrozenEvent(currentHero));
				 Finish();
				 return;
            }

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
			// if (currentHero.TryGetData(out InputEffects inputEffects) && inputEffects.InputEffects.OfType<AttackWrongTargetEffect>().Any())
			// {
			// 	_eventBus.RaiseEvent(new AttackWrongTargetEffect()); // TODO mb remove cringe
			// }

			_eventBus.RaiseEvent(new AttackEvent(currentHero, hero.GetComponent<HeroEntity>()));
			Finish();
		}
	}	
}