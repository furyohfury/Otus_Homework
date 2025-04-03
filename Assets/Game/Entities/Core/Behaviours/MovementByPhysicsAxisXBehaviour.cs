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

		private Vector2 _previousMoveDirection;

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

			if (_moveDirection.Value == Vector2.zero)
			{
				return;
			}

			_rigidbody.AddForce(new Vector2(_moveDirection.Value.x * _moveSpeed.Value, 0));
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