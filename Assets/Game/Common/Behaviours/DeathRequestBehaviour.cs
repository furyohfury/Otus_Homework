using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DeathRequestBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathRequest;
		private ReactiveVariable<int> _health;

		public void Init(IEntity entity)
		{
			_deathRequest = entity.GetDeathRequest();
			_health = entity.GetHealth();
			_health.Subscribe(OnHealthChanged);
		}

		private void OnHealthChanged(int hp)
		{
			if (hp <= 0)
			{
				_deathRequest.Invoke();
			}
		}

		public void Dispose(IEntity entity)
		{
			_health.Unsubscribe(OnHealthChanged);
		}
	}
}