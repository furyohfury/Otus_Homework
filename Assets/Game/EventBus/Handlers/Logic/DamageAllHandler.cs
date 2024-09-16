using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class DamageAllHandler : BaseHandler<DamageAllEvent>
	{
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

		[Inject]
		public DamageAllHandler(EventBus eventBus, Dictionary<Player, HeroCollection> heroCollections) : base(eventBus)
		{
			_heroCollections = heroCollections;
		}

		protected override void OnHandleEvent(DamageAllEvent evt)
		{
			Debug.Log("DamageAllHandler");
			foreach (var heroCollection in _heroCollections.Values)
			{
				foreach (var hero in heroCollection.HeroEntities)
				{
					if (hero != evt.Source)
					{
						EventBus.RaiseEvent(new DealDamageEvent(evt.Source, hero, evt.Damage));
					}
				}
			}
		}
	}
}