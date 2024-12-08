using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class MovementByPhysicsBehaviour : IEntityInit, IEntityFixedUpdate, IEntityEnable, IEntityDisable
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;
		private bool _isActive = true;
		private Vector3 _cachedVelocity;

		private Vector2 _previousMoveDirection;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_canMove = entity.GetCanMove();
			_moveSpeed = entity.GetMoveSpeed();
			_rigidbody = entity.GetRigidbody();
		}

		public void OnFixedUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}
			
			if (!_canMove.Value)
			{
				return;
			}

			if (_moveDirection.Value == Vector2.zero)
			{
				return;
			}
			
			_rigidbody.AddForce(_moveDirection.Value * _moveSpeed.Value);
		}
		
		public void Enable(IEntity entity)
		{
			_isActive = true;
			_rigidbody.velocity = _cachedVelocity;
			_rigidbody.isKinematic = false;
		}

		public void Disable(IEntity entity)
		{
			_isActive = false;
			_cachedVelocity = _rigidbody.velocity;
			_rigidbody.velocity = Vector2.zero;
			_rigidbody.isKinematic = true;
		}
	}
}