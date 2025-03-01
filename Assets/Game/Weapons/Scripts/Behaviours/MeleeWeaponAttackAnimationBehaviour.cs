using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace Game
{
	public sealed class MeleeWeaponAttackAnimationBehaviour : IEntityInit, IEntityDispose, IEntityEnable, IEntityDisable
	{
		private BaseEvent _attackEvent;
		private BaseEvent _deactivateColliderEvent;
		private BaseEvent _activateColliderEvent;
		
		private Transform _transform;
		private IValue<Vector3> _attackRotationAngle;
		private IValue<float> _slashSpeed;
		private IValue<float> _reverseSlashSpeed;

		private Sequence _sequence;

		public void Init(IEntity entity)
		{
			_attackEvent = entity.GetAttackEvent();
			_attackEvent.Subscribe(OnAttack);
			_activateColliderEvent = entity.GetActivateColliderEvent();
			_deactivateColliderEvent = entity.GetDeactivateColliderEvent();

			_transform = entity.GetVisualTransform();
			_attackRotationAngle = entity.GetAttackRotationAngle();
			_slashSpeed = entity.GetSlashSpeed();
			_reverseSlashSpeed = entity.GetReverseSlashSpeed();
		}

		private void OnAttack()
		{
			Vector3 defaultRotation = _transform.rotation.eulerAngles;
			Vector3 attackRotation = _transform.localScale.x > 0
				? defaultRotation + _attackRotationAngle.Value
				: defaultRotation - _attackRotationAngle.Value;

			_sequence = DOTween.Sequence()
			                   .AppendCallback(OnSlashStarted)
			                   .Append(_transform.DORotate(attackRotation, _slashSpeed.Value))
			                   .AppendCallback(OnSlashEnded)
			                   .Append(_transform.DORotate(defaultRotation, _reverseSlashSpeed.Value))
			                   .OnComplete(() => _sequence = null);
			if (_sequence.IsPlaying() == false)
			{
				_sequence.Restart();
			}
			// TODO collider activation in separate bh mb
		}

		private void OnSlashStarted()
		{
			_activateColliderEvent.Invoke();
		}

		private void OnSlashEnded()
		{
			_deactivateColliderEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_attackEvent.Unsubscribe(OnAttack);
		}

		public void Enable(IEntity entity)
		{
			if (_sequence.IsActive() && _sequence.IsComplete() == false)
			{
				_sequence.Play();
			}
		}

		public void Disable(IEntity entity)
		{
			if (_sequence.IsActive() && _sequence.IsPlaying())
			{
				_sequence.Pause();
			}
		}
	}
}