using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class MovementByPhysicsAxisXBehaviour : IEntityInit, IEntityFixedUpdate, IEntityEnable, IEntityDisable
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;
		private Vector3 _cachedVelocity;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_canMove = entity.GetCanMove();
			_moveSpeed = entity.GetMoveSpeed();
			_rigidbody = entity.GetRigidbody2D();
		}

		public void OnFixedUpdate(IEntity entity, float deltaTime)
		{
			if (!_canMove.Value)
			{
				return;
			}

			var direction = _moveDirection.Value;
			if (direction == Vector2.zero)
			{
				return;
			}

			float currentVelocityX = _rigidbody.linearVelocityX;
			float targetVelocityX = direction.x * _moveSpeed.Value;

			if (direction.x != 0)
			{
				if (Mathf.Approximately(Mathf.Sign(currentVelocityX), direction.x) && Mathf.Abs(currentVelocityX) >= Mathf.Abs(targetVelocityX))
				{
					return;
				}

				float velocityDiff = targetVelocityX - currentVelocityX;
				float impulse = _rigidbody.mass * velocityDiff;

				_rigidbody.AddForce(new Vector2(impulse, 0), ForceMode2D.Impulse);
			}
		}

		public void Enable(IEntity entity)
		{
			_rigidbody.linearVelocity = _cachedVelocity;
			_rigidbody.bodyType = RigidbodyType2D.Dynamic;
		}

		public void Disable(IEntity entity)
		{
			_cachedVelocity = _rigidbody.linearVelocity;
			_rigidbody.linearVelocity = Vector2.zero;
			_rigidbody.bodyType = RigidbodyType2D.Kinematic;
		}
	}
}