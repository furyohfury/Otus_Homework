using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementByPhysicsBehaviour : IEntityInit, IEntityFixedUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;

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
			if (!_canMove.Value) return;

			// 1st way
			var velocity = _rigidbody.velocity;
			velocity.x = _moveDirection.Value.x * _moveSpeed.Value;
			_rigidbody.velocity = velocity;
			
			// 2nd way
			// _rigidbody.AddForce(_moveDirection.Value * _moveSpeed.Value);
			
			// 3rd way
			// _rigidbody.velocity += _moveDirection.Value - _previousMoveDirection;
			// _previousMoveDirection = _moveDirection.Value;
		}
	}
}