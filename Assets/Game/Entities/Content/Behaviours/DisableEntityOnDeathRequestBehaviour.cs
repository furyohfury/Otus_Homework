using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DisableEntityOnDeathRequestBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathEvent;
		private IEntity _entity;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_deathEvent = entity.GetDeathEvent();
			_deathEvent.Subscribe(OnDeathRequest);
		}

		private void OnDeathRequest()
		{
			_entity.Disable();
		}

		public void Dispose(IEntity entity)
		{
			_deathEvent.Unsubscribe(OnDeathRequest);
		}
	}
}