using EventBus;
using UnityEngine;
using Zenject;

namespace Entities
{
	public sealed class FireProjectileVisualHandler : BaseHandler<FireProjectileVisualEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private GameObject _projectile;
		private Transform _worldTransform;
	
		[Inject]
		public FireProjectileVisualHandler(EventBus.EventBus eventBus, VisualPipeline visualPipeline, GameObject projectile, Transform worldTransform) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_projectile = projectile;
			_worldTransform = worldTransform;
		}
	
		protected override void OnHandleEvent(FireProjectileVisualEvent evt)
		{
			_visualPipeline.AddTask(new FireProjectileVisualTask(evt.Source, evt.Target, _projectile, _worldTransform));
			Debug.Log("DamageRandomEnemyVisualHandler");
			
		}
	}
}