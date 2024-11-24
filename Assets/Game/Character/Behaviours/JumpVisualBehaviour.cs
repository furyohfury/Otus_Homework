using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class JumpVisualBehaviour : IEntityInit, IEntityDispose
	{
		private Animator _animator;
		private int _jumpAnimationHash;
		private IEvent _jumpEvent;
		
		public void Init(IEntity entity)
		{
			_animator = entity.GetAnimator();
			_jumpEvent = entity.GetJumpEvent();
			_jumpAnimationHash = Animator.StringToHash("Jump");
			_jumpEvent.Subscribe(OnJump);
		}

		private void OnJump()
		{
			_animator.SetTrigger(_jumpAnimationHash);
		}

		public void Dispose(IEntity entity)
		{
			_jumpEvent.Unsubscribe(OnJump);
		}
	}

	public sealed class RotateWeaponBehaviour : IEntityInit
	{
		public void Init(IEntity entity)
		{
			throw new System.NotImplementedException();
		}
	}
}