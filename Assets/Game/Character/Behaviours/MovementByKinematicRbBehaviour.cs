using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementByKinematicRbBehaviour : IEntityInit, IEntityFixedUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;

		private Vector2 _previousMoveDirection;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_moveSpeed = entity.GetMoveSpeed();
			_rigidbody = entity.GetRigidbody();
		}

		public void OnFixedUpdate(IEntity entity, float deltaTime)
		{
			var translation = _moveDirection.Value * (_moveSpeed.Value * deltaTime);
			_rigidbody.MovePosition(_rigidbody.position + translation);
		}
	}
}