using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public class JumpAbilityBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _abilityEvent;
		private BaseEvent _jumpEvent;
		private Rigidbody2D _rigidbody;

		public void Init(IEntity entity)
		{
			_rigidbody = entity.GetRigidbody();
			_abilityEvent = entity.GetAbilityEvent();
			_jumpEvent = entity.GetJumpEvent();
			_abilityEvent.Subscribe(OnJumpAbility);
		}

		private void OnJumpAbility()
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
			_jumpEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnJumpAbility);
		}
	}
}