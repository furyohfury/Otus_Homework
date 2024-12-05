using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SpendAmmoOnAttackBehaviour : IEntityInit, IEntityDispose
	{
		private ReactiveVariable<int> _ammo;
		private BaseEvent _attackEvent;

		public void Init(IEntity entity)
		{
			if (!entity.TryGetAmmo(out _ammo))
			{
				Debug.LogError($"No ammo on {entity.Name}");
			}

			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttack);
		}

		private void OnAttack()
		{
			_ammo.Value = Mathf.Max(0, _ammo.Value - 1);
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttack);
		}
	}
}