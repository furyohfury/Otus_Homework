using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class JumpBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _jumpAction;
		private IValue<bool> _canJump;
		private Rigidbody2D _rigidbody;
		private IValue<float> _jumpForce;

		public void Init(IEntity entity)
		{
			_jumpAction = entity.GetJumpAction();
			_jumpAction.Subscribe(Jump);
			_canJump = entity.GetCanJump();
			_rigidbody = entity.GetRigidbody();
			_jumpForce = entity.GetJumpForce();
		}

		private void Jump()
		{
			if (!_canJump.Value) return;

			_rigidbody.AddForce(new Vector2(0, _jumpForce.Value), ForceMode2D.Impulse);
		}

		public void Dispose(IEntity entity)
		{
			_jumpAction.Unsubscribe(Jump);
		}
	}
}