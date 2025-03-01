using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MeleeWeaponColliderActivationBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _activateColliderEvent;
		private BaseEvent _deactivateColliderEvent;
		private Collider2D _collider2D;

		public void Init(IEntity entity)
		{
			_collider2D = entity.GetCollider2D();

			_activateColliderEvent = entity.GetActivateColliderEvent();
			_activateColliderEvent.Subscribe(OnActivateCollider);
			_deactivateColliderEvent = entity.GetDeactivateColliderEvent();
			_deactivateColliderEvent.Subscribe(OnDeactivateCollider);
		}

		private void OnActivateCollider()
		{
			_collider2D.enabled = true;
		}

		private void OnDeactivateCollider()
		{
			_collider2D.enabled = false;
		}

		public void Dispose(IEntity entity)
		{
			_activateColliderEvent.Unsubscribe(OnActivateCollider);
			_deactivateColliderEvent.Unsubscribe(OnDeactivateCollider);
		}
	}
}