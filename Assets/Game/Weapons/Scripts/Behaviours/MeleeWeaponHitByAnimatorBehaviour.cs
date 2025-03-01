using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class MeleeWeaponHitByAnimatorBehaviour : IEntityInit, IEntityDispose
	{
		private const string ACTIVATE_COLLIDER = "ActivateCollider";
		private const string DEACTIVATE_COLLIDER = "DeactivateCollider";

		private ReactiveVariable<SceneEntity> _weapon;
		private BaseEvent _activateColliderWeaponEvent;
		private BaseEvent _deactivateColliderWeaponEvent;
		private AnimatorEventReceiver _animatorEventReceiver;

		public void Init(IEntity entity)
		{
			_weapon = entity.GetWeapon();
			_activateColliderWeaponEvent = _weapon.Value.GetActivateColliderEvent();
			_deactivateColliderWeaponEvent = _weapon.Value.GetDeactivateColliderEvent();

			_animatorEventReceiver = entity.GetAnimatorEventReceiver();
			_animatorEventReceiver.SubscribeOnEvent(ACTIVATE_COLLIDER, OnActivateCollider);
			_animatorEventReceiver.SubscribeOnEvent(DEACTIVATE_COLLIDER, OnDeactivateCollider);
		}

		private void OnActivateCollider()
		{
			_activateColliderWeaponEvent.Invoke();
		}

		private void OnDeactivateCollider()
		{
			_deactivateColliderWeaponEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_animatorEventReceiver.UnsubscribeOnEvent(ACTIVATE_COLLIDER, OnActivateCollider);
			_animatorEventReceiver.UnsubscribeOnEvent(DEACTIVATE_COLLIDER, OnDeactivateCollider);
		}
	}
}