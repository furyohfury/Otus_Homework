using Entities;
using UnityEngine;

namespace EventBus
{
	public class DamageAllVisualTask : EventTask
	{
		private readonly ParticleSystem _particleSystem;
		private readonly Entity _hero;

		public DamageAllVisualTask(ParticleSystem particleSystem, Entity hero)
		{
			_particleSystem = particleSystem;
			_hero = hero;
		}

		protected override void OnRun()
		{
			Debug.Log("DamageAllVisualTask OnRun");
			var container = _hero.GetData<HeroViewComponent>().Container;
			var position = container.transform.position;
			var particles = Object.Instantiate(_particleSystem, position, Quaternion.identity, container.transform);
			var main = particles.main;
			main.stopAction = ParticleSystemStopAction.Destroy;
			particles.Play();
			Finish();
		}
	}
}