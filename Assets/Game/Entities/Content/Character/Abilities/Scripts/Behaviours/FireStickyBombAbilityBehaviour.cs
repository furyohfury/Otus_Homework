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
		private Transform _root;

		public void Init(IEntity entity)
		{
			if (SceneEntity.TryCast(entity, out var sceneEntity))
			{
				_root = sceneEntity.transform.root;
			}

			_stickyBombPrefab = entity.GetStickyBombPrefab();
			_abilityEvent = entity.GetAbilityEvent();
			var weapon = entity.GetWeapon().Value;
			_firePoint = weapon.GetFirePoint();
			_abilityEvent.Subscribe(OnAbilityEvent);
		}

		private void OnAbilityEvent()
		{
			var firePointTransform = _firePoint.Value;
			var bomb = SceneEntity.Instantiate(_stickyBombPrefab,
				firePointTransform.position,
				firePointTransform.rotation,
				_root);

			var rigidbody = bomb.GetRigidbody2D();
			var direction = rigidbody.transform.right;
			rigidbody.AddForce(direction * 2000);
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnAbilityEvent);
		}
	}
}