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
			var heroView = _hero.GetData<HeroViewComponent>().HeroView;
			var position = heroView.transform.position;
			var particles = Object.Instantiate(_particleSystem, position, Quaternion.identity, heroView.transform);
			var main = particles.main;
			main.stopAction = ParticleSystemStopAction.Destroy;
			particles.Play();
			Finish();
		}
	}
}