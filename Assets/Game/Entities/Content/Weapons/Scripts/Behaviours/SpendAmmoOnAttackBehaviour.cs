using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SpendAmmoOnAttackBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private IEntity _entity;

		public void Init(IEntity entity)
		{
			_entity = entity;

			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttack);
		}

		private void OnAttack()
		{
			if (!_entity.TryGetAmmo(out ReactiveVariable<int> ammo))
			{
				return;
			}
			
			ammo.Value = Mathf.Max(0, ammo.Value - 1);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttack);
		}
	}
}