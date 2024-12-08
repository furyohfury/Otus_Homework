using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class MovementAnimatorBehaviour : IEntityInit, IEntityUpdate, IEntityEnable, IEntityDisable
	{
		private Animator _animator;
		private IValue<Vector2> _moveDirection;
		private int _moveAnimationHash;
		private bool _isActive = true;
		
		public void Init(IEntity entity)
		{
			_animator = entity.GetAnimator();
			_moveDirection = entity.GetMoveDirection();
			_moveAnimationHash = Animator.StringToHash("IsMoving");
		}


		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}
			var isMoving = _moveDirection.Value != Vector2.zero;
			_animator.SetBool(_moveAnimationHash, isMoving);
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