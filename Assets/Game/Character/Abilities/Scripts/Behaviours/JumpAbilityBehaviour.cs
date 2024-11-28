using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public class JumpAbilityBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _abilityEvent;
		private BaseEvent _jumpEvent;

		public void Init(IEntity entity)
		{
			_abilityEvent = entity.GetAbilityEvent();
			_jumpEvent = entity.GetJumpEvent();
			_abilityEvent.Subscribe(OnJumpAbility);
		}

		private void OnJumpAbility()
		{
			_jumpEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnJumpAbility);
		}
	}
}