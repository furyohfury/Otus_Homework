using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace Game
{
	public sealed class SwordAttackAnimationBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _swordEntity;
		private Collider2D _swordCollider;
		private Transform _swordVisualTransform;
		private BaseEvent _swordAttackEvent;
		
		private Vector3 _defaultRotation;
		private IValue<Vector3> _rotationAngle;
		private IValue<float> _slashSpeed;
		private IValue<float> _restoreSlashSpeed;

		private Sequence _sequence;

		public void Init(IEntity entity)
		{
			_swordAttackEvent = entity.GetAttackEvent();
			_swordAttackEvent.Subscribe(OnSwordAttack);

			_swordEntity = entity.GetSword();
			_swordVisualTransform = _swordEntity.GetVisualTransform();
			_defaultRotation = _swordVisualTransform.rotation.eulerAngles;
			_rotationAngle = _swordEntity.GetAttackRotationAngle();
			_swordCollider = _swordEntity.GetCollider2D();
			_slashSpeed = _swordEntity.GetSlashSpeed();
			_restoreSlashSpeed = _swordEntity.GetRestoreSlashSpeed();
		}

		private void OnSwordAttack()
		{
			if (_sequence != null)
			{
				return;
			}

			_sequence = DOTween.Sequence()
			                   .AppendCallback(OnSlashStarted)
			                   .Append(_swordVisualTransform.DORotate(_defaultRotation + _rotationAngle.Value, _slashSpeed.Value))
			                   .AppendCallback(OnSlashEnded)
			                   .Append(_swordVisualTransform.DORotate(_defaultRotation, _restoreSlashSpeed.Value))
			                   .OnComplete(() => _sequence = null);
			// TODO mb cancellation token
			// TODO collider activation in separate bh mb
			_sequence.Play();
		}

		private void OnSlashStarted()
		{
			_swordCollider.enabled = true;
		}

		private void OnSlashEnded()
		{
			_swordCollider.enabled = false;
		}

		public void Dispose(IEntity entity)
		{
			_swordAttackEvent.Unsubscribe(OnSwordAttack);
		}
	}
}