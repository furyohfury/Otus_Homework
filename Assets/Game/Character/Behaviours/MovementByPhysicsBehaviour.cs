using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class MovementByPhysicsBehaviour : IEntityInit, IEntityFixedUpdate
	{
		private IValue<Vector2> _moveDirection;
		private IValue<float> _moveSpeed;
		private Rigidbody2D _rigidbody;
		private AndExpression _canMove;

		private Vector2 _previousMoveDirection;

		[SerializeField]
		private float _acceleration = 1000f;
		

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
			// var velocity = _rigidbody.velocity;
			// velocity.x = _moveDirection.Value.x * _moveSpeed.Value;
			// _rigidbody.velocity = velocity;
			
			// 2nd way
			// _rigidbody.AddForce(_moveDirection.Value * _moveSpeed.Value);
			
			// 3rd way
			// _rigidbody.velocity += _moveDirection.Value - _previousMoveDirection;
			// _previousMoveDirection = _moveDirection.Value;
			
			// 4th way
			// Текущая скорость
			Vector2 targetVelocity = new Vector2(_moveDirection.Value.x * _moveSpeed.Value, _rigidbody.velocity.y);
			
			// Ускорение для быстрого набора скорости
			Vector2 velocityChange = targetVelocity - _rigidbody.velocity;
			velocityChange.x = Mathf.Clamp(velocityChange.x, -_acceleration * deltaTime, _acceleration * deltaTime);
			
			// Применяем силу
			_rigidbody.AddForce(velocityChange * _rigidbody.mass, ForceMode2D.Force);
			
			
		}
	}
}