using System;
using System.Collections.Generic;
using EventBus;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Entities
{
	[Serializable]
	public sealed class EndOfTurnComponent : IComponent
	{
		[SerializeReference]
		public List<ICombatEvent> Events = new();
	}	

	[Serializable]
	public struct DamageRandomEnemyEvent : ICombatEvent
	{
		public Entity Source { get; set; }
		public int Damage;
	}

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
			EventBus.RaiseEvent(new DealDamageEvent(randomEnemy, evt.Damage));
		}
	}

	public sealed class DamageRandomEnemyVisualHandler : BaseHandler<DamageRandomEnemyEvent>
	{
		private readonly VisualPipeline _visualPipeline;
	
		[Inject]
		public DamageRandomEnemyVisualHandler(EventBus.EventBus eventBus, VisualPipeline visualPipeline) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
		}
	
		protected override void OnHandleEvent(DamageRandomEnemyEvent evt)
		{
			// _visualPipeline.AddTask(new );
			Debug.Log("DamageRandomEnemyVisualHandler");
			
		}
	}
}