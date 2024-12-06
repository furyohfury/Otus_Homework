using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class LifetimeBehaviour : IEntityInit, IEntityDispose
	{
		private Timer _lifetimeTimer;
		private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_deathEvent = entity.GetDeathEvent();
			_lifetimeTimer = entity.GetLifetimeTimer();
			_lifetimeTimer.OnEnded += OnTimerEnded;
		}

		private void OnTimerEnded()
		{
			_deathEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_lifetimeTimer.OnEnded -= OnTimerEnded;
		}
	}
}