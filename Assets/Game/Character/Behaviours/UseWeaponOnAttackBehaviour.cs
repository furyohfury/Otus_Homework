using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class UseWeaponOnAttackBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _entity;
		private BaseEvent _attackEvent;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttackEvent);
		}

		private void OnAttackEvent()
		{
			if (!_entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				return;
			}
			
			weapon.Value.GetAttackRequest().Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttackEvent);
		}
	}
}