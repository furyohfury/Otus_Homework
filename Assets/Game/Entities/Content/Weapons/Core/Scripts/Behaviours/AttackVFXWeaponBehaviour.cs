using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AttackVFXWeaponBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private AnimatedVFX _attackVFX;

		public void Init(IEntity entity)
		{
			_attackVFX = entity.GetAttackVFX();
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttack);
		}

		private void OnAttack()
		{
			_attackVFX.Show();
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttack);
		}
	}
}