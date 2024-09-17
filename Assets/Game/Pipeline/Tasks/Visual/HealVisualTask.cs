using Entities;
using UnityEngine;

namespace EventBus
{
	public class HealVisualTask : EventTask
	{
		private readonly Entity _target;
		private readonly ParticleSystem _particleSystem;

		public HealVisualTask(Entity target, ParticleSystem particleSystem)
		{
			_target = target;
			_particleSystem = particleSystem;
		}

		protected override void OnRun()
		{
			Debug.Log("HealVisualTask OnRun");
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			var container = targetHeroViewComponent.Container;
			var particles = Object.Instantiate(_particleSystem, container.position, Quaternion.identity, container);
			var psMain = particles.main;
			psMain.stopAction = ParticleSystemStopAction.Destroy;
			particles.Play();
			Finish();
		}
	}
}