using System;
using System.Collections.Generic;
using DG.Tweening;
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
			EventBus.RaiseEvent(new DealDamageEvent(evt.Source, randomEnemy, evt.Damage));
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
			// _visualPipeline.AddTask(new ThrowProjectileVisualTask(projectile));
			Debug.Log("DamageRandomEnemyVisualHandler");
			
		}
	}

	public class ThrowProjectileVisualTask : EventTask
	{
		private readonly Entity _source;
		private readonly Entity _target;
		private GameObject _projectile;
		private Transform _worldTransform;


		public ThrowProjectileVisualTask(Entity source, Entity target, GameObject projectile, Transform worldTransform)
		{
			_source = source;
			_target = target;
			_projectile = projectile;
			_worldTransform = worldTransform;
		}

		protected override void OnRun()
		{
			Debug.Log("ThrowProjectileVisualTask OnRun");
			var sourceHeroViewComponent = _source.GetData<HeroViewComponent>();
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			var startPos = sourceHeroViewComponent.Container.position;
			var endPos = targetHeroViewComponent.Container.position;
			
			var projectile = GameObject.Instantiate(_projectile, startPos, Quaternion.identity, _worldTransform);
			projectile.transform.DOMove(endPos, 1f).OnComplete(Finish);
		}
	}
}