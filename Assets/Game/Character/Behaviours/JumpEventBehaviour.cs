using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class JumpEventBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _jumpEvent;
		private Rigidbody2D _rigidbody;
		private IValue<float> _jumpForce;

		public void Init(IEntity entity)
		{
			_rigidbody = entity.GetRigidbody();
			_jumpForce = entity.GetJumpForce();
			_jumpEvent = entity.GetJumpEvent();
			_jumpEvent.Subscribe(OnJumpEvent);
		}

		private void OnJumpEvent()
		{
			_rigidbody.AddForce(new Vector2(0, _jumpForce.Value), ForceMode2D.Impulse);
		}

		public void Dispose(IEntity entity)
		{
			_jumpEvent.Unsubscribe(OnJumpEvent);
		}
	}
}