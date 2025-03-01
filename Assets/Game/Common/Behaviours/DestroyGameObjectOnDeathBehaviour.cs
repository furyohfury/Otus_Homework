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
			_deathEvent.Subscribe(OnDeath);
			// _entity = (SceneEntity)entity;
			// TODO
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