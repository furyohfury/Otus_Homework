using Entities;
using UnityEngine;

namespace EventBus
{
	public class DealDamageVisualTask : EventTask
	{
		private readonly Entity _target;
        private int _health;
        private int _damage;
        private ParticleSystem _particles;


		public DealDamageVisualTask(Entity target, int damage, int health)
		{
			_target = target;
            _damage = damage;
            _health = health;
		}

		protected override async void OnRun()
		{
			Debug.Log("DealDamageVisualTask OnRun");
			_target.TryGetData(out HeroViewComponent targetHeroViewComponent);
            targetHeroViewComponent.HeroView.SetStats($"{_damage/_health}");
            var position = targetHeroViewComponent.HeroView.transform.position;
            var particles = ParticleSystem.Instantiate(_particles, position, Quaternion.identity);
            particles.Play();
			Finish();
		}
	}
}