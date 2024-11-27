using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DestroyGameObjectOnDeathBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _deathEvent;
		private SceneEntity _entity;

		public void Init(IEntity entity)
		{
			_deathEvent = entity.GetDeathEvent();
			if (entity is SceneEntity sceneEntity)
			{
				_entity = sceneEntity;
				_deathEvent.Subscribe(OnDeath);
			}
		}

		private void OnDeath()
		{
			Object.Destroy(_entity);
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