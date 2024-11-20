using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementBehaviour : IEntityInit, IEntityFixedUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;

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

			var velocity = _rigidbody.velocity;
			velocity.x = _moveDirection.Value.x * _moveSpeed.Value;
			_rigidbody.velocity = velocity;
		}
	}
}