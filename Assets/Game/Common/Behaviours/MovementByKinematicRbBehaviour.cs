using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementByKinematicRbBehaviour : IEntityInit, IEntityFixedUpdate, IEntityEnable, IEntityDisable
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;
		
		private bool _isActive = true;

		public void Init(IEntity entity)
		{
			_moveDirection = entity.GetMoveDirection();
			_moveSpeed = entity.GetMoveSpeed();
			_rigidbody = entity.GetRigidbody();
		}

		public void OnFixedUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}
			var translation = _moveDirection.Value * (_moveSpeed.Value * deltaTime);
			_rigidbody.MovePosition(_rigidbody.position + translation);
		}
		
		public void Enable(IEntity entity)
		{
			_isActive = true;
		}

		public void Disable(IEntity entity)
		{
			_isActive = false;
		}
	}
}