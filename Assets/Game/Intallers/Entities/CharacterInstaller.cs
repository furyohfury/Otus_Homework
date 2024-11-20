using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
	[Serializable]
	public sealed class CharacterInstaller : IEntityInstaller
	{
		[Header("Components")]
		[SerializeField]
		private Rigidbody2D _rigidBody;
		[SerializeField]
		private Animator _animator;

		[SerializeField] [Header("Movement")]
		private ReactiveVariable<float> _moveSpeed;
		[SerializeField]
		private ReactiveVariable<float> _jumpForce;
		[SerializeField]
		private Transform _groundCheckTransform;
		[SerializeField]
		private LayerMask _groundLayer;

		private readonly AndExpression _canMove = new();
		private readonly AndExpression _canJump = new();

		public void Install(IEntity entity)
		{
			InitializeMovement(entity);
			InitializeComponents(entity);
		}

		private void InitializeComponents(IEntity entity)
		{
			entity.AddRigidbody(_rigidBody);
			entity.AddAnimator(_animator);
		}

		private void InitializeMovement(IEntity entity)
		{
			// State
			entity.AddMoveSpeed(_moveSpeed);
			entity.AddMoveDirection(new ReactiveVariable<Vector2>());
			// CanMove init
			_canMove.Append(() => true);
			entity.AddCanMove(_canMove);

			// CanJump init
			var distance = ((Vector2)_groundCheckTransform.position - _rigidBody.position).magnitude;
			var isGrounded = new BaseFunction<bool>(() =>
			{
				var i = Physics2D.Raycast(_rigidBody.position, Vector2.down, distance, _groundLayer);
				return i != default;
			});
			entity.AddIsGrounded(isGrounded);

			_canJump.Append(entity.GetIsGrounded());
			entity.AddCanJump(_canJump);
			entity.AddJumpForce(_jumpForce);
			entity.AddJumpRequest(new BaseEvent());
			entity.AddJumpEvent(new BaseEvent());

			// Behaviours
			entity.AddBehaviour(new MovementBehaviour());
			entity.AddBehaviour(new JumpBehaviour());
			entity.AddBehaviour(new MovementVisualBehaviour());
			entity.AddBehaviour(new JumpVisualBehaviour());
		}
	}
}