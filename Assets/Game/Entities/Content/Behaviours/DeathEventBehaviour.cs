using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DeathEventBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathRequest;
		private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
			_deathEvent = entity.GetDeathEvent();
		}

		private void OnDeathRequest()
		{
			_deathEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}