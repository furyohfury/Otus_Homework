using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementByTransformBehaviour : IEntityInit, IEntityUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Transform _transform;
		private AndExpression _canMove;

		private Vector2 _previousMoveDirection;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_moveSpeed = entity.GetMoveSpeed();
			_transform = entity.GetVisualTransform();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			var translation = _moveDirection.Value * (_moveSpeed.Value * deltaTime);
			_transform.Translate(translation, Space.World);
		}
	}
	
	public sealed class MovementByTransformBehaviour : IEntityInit, IEntityUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Transform _transform;
		private AndExpression _canMove;

		private Vector2 _previousMoveDirection;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_moveSpeed = entity.GetMoveSpeed();
			_transform = entity.GetVisualTransform();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			var translation = _moveDirection.Value * (_moveSpeed.Value * deltaTime);
			_transform.Translate(translation, Space.World);
		}
	}
}