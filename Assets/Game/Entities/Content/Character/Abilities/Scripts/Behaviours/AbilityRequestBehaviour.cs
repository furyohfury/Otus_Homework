using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class AbilityRequestBehaviour : IEntityInit, IEntityDispose
	{
		private BaseEvent _abilityRequest;
		private BaseEvent _abilityEvent;
		private IFunction<bool> _canUseAbility;

		public void Init(IEntity entity)
		{
			_abilityRequest = entity.GetAbilityRequest();
			_abilityEvent = entity.GetAbilityEvent();
			_canUseAbility = entity.GetCanUseAbility();
			_abilityRequest.Subscribe(OnAbilityRequest);
		}

		private void OnAbilityRequest()
		{
			if (_canUseAbility.Invoke() == true)
			{
				_abilityEvent.Invoke();
			}
		}

		public void Dispose(IEntity entity)
		{
			_abilityRequest.Unsubscribe(OnAbilityRequest);
		}
	}
}