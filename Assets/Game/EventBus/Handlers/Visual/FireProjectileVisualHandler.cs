using EventBus;
using UnityEngine;
using Zenject;

namespace Entities
{
	public sealed class FireProjectileVisualHandler : BaseHandler<FireProjectileVisualEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly Transform _worldTransform;

		[Inject]
		public FireProjectileVisualHandler(EventBus.EventBus eventBus, VisualPipeline visualPipeline,
			Transform worldTransform) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_worldTransform = worldTransform;
		}

		protected override void OnHandleEvent(FireProjectileVisualEvent evt)
		{
			Debug.Log("FireProjectileVisualHandler");
			_visualPipeline.AddTask(new FireProjectileVisualTask(evt.Source, evt.Target, evt.Projectile,
				_worldTransform));
		}
	}
}