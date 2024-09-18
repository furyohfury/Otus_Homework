using System.Collections.Generic;
using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class AttackWrongTargetHandler : BaseHandler<AttackWrongTargetEvent>
	{
		private readonly Dictionary<Player, HeroCollection> _heroCollections;
		private readonly CurrentHeroService _currentHeroService;

		[Inject]
		public AttackWrongTargetHandler(EventBus eventBus, Dictionary<Player, HeroCollection> heroCollections,
			CurrentHeroService currentHeroService) : base(eventBus)
		{
			_heroCollections = heroCollections;
			_currentHeroService = currentHeroService;
		}

		protected override void OnHandleEvent(AttackWrongTargetEvent evt)
		{
			var player = evt.InitialTarget.GetData<PlayerComponent>().Player;
			var availableTargets = _heroCollections[player];
			var currentHero = _currentHeroService.CurrentHero;

			if (Random.value > evt.Probability && availableTargets.Count <= 1)
			{
				EventBus.RaiseEvent(new AttackEvent(currentHero, evt.InitialTarget.GetComponent<Entity>()));
			}
			else
			{
				Entity newTarget;
				do
				{
					var index = Random.Range(0, availableTargets.Count - 1);
					newTarget = availableTargets.HeroEntities[index];
				} while (newTarget == evt.InitialTarget);

				EventBus.RaiseEvent(new AttackEvent(currentHero, newTarget));
			}
		}
	}
}