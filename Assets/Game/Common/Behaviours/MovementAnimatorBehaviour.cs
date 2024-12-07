using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementAnimatorBehaviour : IEntityInit, IEntityUpdate
	{
		private Animator _animator;
		private IValue<Vector2> _moveDirection;
		private int _moveAnimationHash;
		
		public void Init(IEntity entity)
		{
			_animator = entity.GetAnimator();
			_moveDirection = entity.GetMoveDirection();
			_moveAnimationHash = Animator.StringToHash("IsMoving");
		}


		public void OnUpdate(IEntity entity, float deltaTime)
		{
			var isMoving = _moveDirection.Value != Vector2.zero;
			_animator.SetBool(_moveAnimationHash, isMoving);
		}
	}
}