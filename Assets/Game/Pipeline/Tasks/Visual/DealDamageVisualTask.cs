using Entities;
using UnityEngine;

namespace EventBus
{
	public class DealDamageVisualTask : EventTask
	{
		private readonly Entity _target;
		private readonly int _health;
		private readonly int _damage;
		private readonly ParticleSystem _particles;

		public DealDamageVisualTask(Entity target, int damage, int health, ParticleSystem particleSystem)
		{
			_target = target;
			_damage = damage;
			_health = health;
			_particles = particleSystem;
		}

		protected override void OnRun()
		{
			Debug.Log("DealDamageVisualTask OnRun");
			_target.TryGetData(out HeroViewComponent targetHeroViewComponent);
			targetHeroViewComponent.HeroView.SetStats($"{_damage}/{_health}");
			var position = targetHeroViewComponent.HeroView.transform.position;
			var particles = ParticleSystem.Instantiate(_particles, position, Quaternion.identity);
			var psMain = particles.main;
			psMain.stopAction = ParticleSystemStopAction.Destroy;
			particles.Play(); // TODO mb change view anyway cuz cant have callback when attacked
			Finish();
		}
	}
}