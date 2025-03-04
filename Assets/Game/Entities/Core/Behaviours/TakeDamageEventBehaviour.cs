using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class TakeDamageEventBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent<int> _takeDamageEvent;
		private ReactiveVariable<int> _health;

		public void Init(IEntity entity)
		{
			_health = entity.GetHealth();
			_takeDamageEvent = entity.GetTakeDamageEvent();
			_takeDamageEvent.Subscribe(OnTakeDamageEvent);
		}

		private void OnTakeDamageEvent(int damage)
		{
			_health.Value -= damage;
		}

		public void Dispose(IEntity entity)
		{
			_takeDamageEvent.Unsubscribe(OnTakeDamageEvent);
		}
	}
}