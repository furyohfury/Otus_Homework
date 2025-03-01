using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DeathEventBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _deathEvent;
		private ReactiveVariable<int> _health;

		public void Init(IEntity entity)
		{
			_deathEvent = entity.GetDeathEvent();
			_health = entity.GetHealth();
			_health.Subscribe(OnHealthChanged);
		}

		private void OnHealthChanged(int hp)
		{
			if (hp <= 0)
			{
				_deathEvent.Invoke();
			}
		}

		public void Dispose(IEntity entity)
		{
			_health.Unsubscribe(OnHealthChanged);
		}
	}
}