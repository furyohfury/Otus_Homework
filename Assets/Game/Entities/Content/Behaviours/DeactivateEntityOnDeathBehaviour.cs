using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DeactivateEntityOnDeathBehaviour : IEntityInit, IEntityDispose
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
			if (SceneEntity.TryCast(_entity, out SceneEntity sceneEntity))
			{
				sceneEntity.gameObject.SetActive(false);
			}
		}

		public void Dispose(IEntity entity)
		{
			_deathEvent.Unsubscribe(OnDeath);
		}
	}
}