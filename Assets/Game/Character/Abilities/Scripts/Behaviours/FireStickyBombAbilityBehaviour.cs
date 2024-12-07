using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class FireStickyBombAbilityBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _abilityEvent;
		private SceneEntity _stickyBombPrefab;
		private IValue<Transform> _firePoint;

		public void Init(IEntity entity)
		{
			_stickyBombPrefab = entity.GetStickyBombPrefab();
			_abilityEvent = entity.GetAbilityEvent();
			var weapon = entity.GetWeapon().Value;
			_firePoint = weapon.GetFirePoint();
			_abilityEvent.Subscribe(OnAbilityEvent);
		}

		private void OnAbilityEvent()
		{
			var bomb = SceneEntity.Instantiate(_stickyBombPrefab, _firePoint.Value.position, _firePoint.Value.rotation);
			var rigidbody = bomb.GetRigidbody();
			var direction = rigidbody.transform.right;
			rigidbody.AddForce(direction * 2000);
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnAbilityEvent);
		}
	}
}