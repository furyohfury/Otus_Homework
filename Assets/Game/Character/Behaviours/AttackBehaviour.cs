using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AttackBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _attackEvent;
		private BaseEvent _attackRequest;
		private IValue<bool> _canAttack;

		public void Init(IEntity entity)
		{
			_canAttack = entity.GetCanAttack();
			_attackRequest = entity.GetAttackRequest();
			_attackEvent = entity.GetAttackEvent();

			_attackRequest.Subscribe(OnAttackRequest);
		}

		private void OnAttackRequest()
		{
			if (_canAttack.Value)
			{
				_attackEvent.Invoke();
			}
		}

		public void Dispose(IEntity entity)
		{
			_attackRequest.Unsubscribe(OnAttackRequest);
		}
	}
}