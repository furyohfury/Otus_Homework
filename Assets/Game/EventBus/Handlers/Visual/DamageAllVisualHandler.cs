using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class DamageAllVisualHandler : BaseHandler<DamageAllEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly ParticleSystem _particleSystem;

		[Inject]
		public DamageAllVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, ParticleSystem particleSystem) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_particleSystem = particleSystem;
		}

		protected override void OnHandleEvent(DamageAllEvent evt)
		{
			Debug.Log("DamageAllVisualHandler");
			_visualPipeline.AddTask(new DamageAllVisualTask(_particleSystem, evt.Source));
		}
	}
}