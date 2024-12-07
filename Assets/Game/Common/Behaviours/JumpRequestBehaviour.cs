using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class JumpRequestBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _jumpRequest;
		private BaseEvent _jumpEvent;
		private IValue<bool> _canJump;

		public void Init(IEntity entity)
		{
			_canJump = entity.GetCanJump();
			_jumpRequest = entity.GetJumpRequest();
			_jumpRequest.Subscribe(OnJumpRequest);
			_jumpEvent = entity.GetJumpEvent();
		}

		private void OnJumpRequest()
		{
			if (!_canJump.Value)
			{
				return;
			}
			
			_jumpEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_jumpRequest.Unsubscribe(OnJumpRequest);
		}
	}
}