using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MeleeWeaponDeflectProjectilesBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent<Collider2D> _triggerEnterEvent;

		public void Init(IEntity entity)
		{
			_triggerEnterEvent = entity.GetTriggerEnterEvent();
			_triggerEnterEvent.Subscribe(OnTriggerEnter);
		}

		private void OnTriggerEnter(Collider2D other)
		{
			if (other.TryGetEntity(out var entity) == false
				|| entity.HasBulletTag() == false
				|| entity.TryGetVisualTransform(out var transform) == false
				|| transform.gameObject.layer != Layers.EnemyProjectile)
			{
				return;
			}

			ReactiveVariable<Vector2> moveDirection = entity.GetMoveDirection();
			moveDirection.Value = -moveDirection.Value;
			transform.gameObject.layer = Layers.CharacterProjectile;
		}

		public void Dispose(IEntity entity)
		{
			_triggerEnterEvent.Unsubscribe(OnTriggerEnter);
		}
	}
}