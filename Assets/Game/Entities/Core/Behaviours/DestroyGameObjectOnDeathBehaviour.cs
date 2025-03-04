using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DestroyGameObjectOnDeathBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _deathEvent;
		private IEntity _entity;

		public void Init(IEntity entity)
		{
			_deathEvent = entity.GetDeathEvent();
			_deathEvent.Subscribe(OnDeath);

			_entity = entity;
		}

		private void OnDeath()
		{
			_deathEvent.Unsubscribe(OnDeath);
			SceneEntity.Destroy(_entity);
		}

		public void Dispose(IEntity entity)
		{
			if (_entity != null)
			{
				_deathEvent.Unsubscribe(OnDeath);
			}
		}
	}
}