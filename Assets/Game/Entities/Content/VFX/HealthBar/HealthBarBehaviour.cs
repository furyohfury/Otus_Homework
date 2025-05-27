using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class HealthBarBehaviour : IEntityInit, IEntityDispose
	{
		private ReactiveVariable<int> _health;
		private HealthBar _healthBar;
		private ReactiveVariable<int> _maxHealth;

		public void Init(IEntity entity)
		{
			_healthBar = entity.GetHealthBar();
			_maxHealth = entity.GetMaxHealth();
			_health = entity.GetHealth();
			_health.Subscribe(OnHealthChanged);
		}

		private void OnHealthChanged(int health)
		{
			_healthBar.SetBar((float)health / _maxHealth.Value);
		}

		public void Dispose(IEntity entity)
		{
			_health.Unsubscribe(OnHealthChanged);
		}
	}
}