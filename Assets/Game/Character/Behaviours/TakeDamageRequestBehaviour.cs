using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class TakeDamageRequestBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent<int> _takeDamageRequest;
		private BaseEvent<int> _takeDamageEvent;
		private IValue<bool> _canTakeDamage;

		public void Init(IEntity entity)
		{
			_takeDamageRequest = entity.GetTakeDamageRequest();
			_takeDamageEvent = entity.GetTakeDamageEvent();
			_canTakeDamage = entity.GetCanTakeDamage();
			_takeDamageRequest.Subscribe(OnTakeDamageRequest);
		}

		private void OnTakeDamageRequest(int damage)
		{
			if (_canTakeDamage.Value)
			{
				_takeDamageEvent.Invoke(damage);
			}
		}

		public void Dispose(IEntity entity)
		{
			_takeDamageRequest.Unsubscribe(OnTakeDamageRequest);
		}
	}
}