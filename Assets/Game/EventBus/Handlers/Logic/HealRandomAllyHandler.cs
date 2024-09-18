using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace EventBus
{
	public sealed class HealRandomAllyHandler : BaseHandler<HealRandomAllyEvent>
	{
		private CurrentHeroService _currentHeroService;
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

		public HealRandomAllyHandler(EventBus eventBus, Dictionary<Player, HeroCollection> heroCollections) :
			base(eventBus)
		{
			_heroCollections = heroCollections;
		}

		protected override void OnHandleEvent(HealRandomAllyEvent evt)
		{
			Debug.Log($"HealRandomAllyHandler, Source: {evt.Source}");

			var player = evt.Source.GetData<PlayerComponent>().Player;
			var heroes = _heroCollections[player].HeroEntities;
			var randomAlly = heroes[Random.Range(0, heroes.Count)];
			EventBus.RaiseEvent(new HealEvent(randomAlly, evt.Amount));
		}
	}
}