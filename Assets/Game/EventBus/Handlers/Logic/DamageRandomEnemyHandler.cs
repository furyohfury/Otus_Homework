using System.Collections.Generic;
using EventBus;
using UnityEngine;
using Zenject;

namespace Entities
{
	public sealed class DamageRandomEnemyHandler : BaseHandler<DamageRandomEnemyEvent>
	{
		private readonly Dictionary<Player, HeroCollection> _heroCollections;

		[Inject]
		public DamageRandomEnemyHandler(EventBus.EventBus eventBus, Dictionary<Player, HeroCollection> heroCollections)
			: base(eventBus)
		{
			_heroCollections = heroCollections;
		}

		protected override void OnHandleEvent(DamageRandomEnemyEvent evt)
		{
			Debug.Log("DamageRandomEnemyEvent handled");
			var currentPlayer = evt.Source.GetData<PlayerComponent>().Player;
			var enemyPlayer = currentPlayer == Player.Blue
				? Player.Red
				: Player.Blue;
			var enemyHeroes = _heroCollections[enemyPlayer].HeroEntities;
			var randomEnemy = enemyHeroes[Random.Range(0, enemyHeroes.Count)];
			if (evt.Projectile != null)
			{
				EventBus.RaiseEvent(new FireProjectileVisualEvent(evt.Source, randomEnemy, evt.Projectile));
			}			
			EventBus.RaiseEvent(new DealDamageEvent(evt.Source, randomEnemy, evt.Damage));
		}
	}
}