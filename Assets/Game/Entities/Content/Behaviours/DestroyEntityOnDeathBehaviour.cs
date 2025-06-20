using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class DestroyEntityOnDeathBehaviour : IEntityInit, IEntityDispose
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
			SceneEntity.Destroy(_entity);
		}

		public void Dispose(IEntity entity)
		{
			_deathEvent.Unsubscribe(OnDeath);
			DestroyChildEntities(entity);
		}

		private void DestroyChildEntities(IEntity entity)
		{
			foreach (var state in entity.Values.Values)
			{
				if (state is SceneEntity sceneEntity)
				{
					SceneEntity.Destroy(sceneEntity);
				}

				if (state is ReactiveVariable<SceneEntity> reactiveVariable)
				{
					SceneEntity.Destroy(reactiveVariable.Value);
				}
			}
		}
	}
}