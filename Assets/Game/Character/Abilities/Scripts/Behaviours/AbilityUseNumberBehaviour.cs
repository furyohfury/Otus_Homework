using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class AbilityUseNumberBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _character;
		private BaseEvent _abilityEvent;
		private ReactiveVariable<int> _abilityUseNumber;
		private IEvent _removeActiveAbilityEvent;

		public void Init(IEntity entity)
		{
			_removeActiveAbilityEvent = entity.GetRemoveActiveAbilityEvent();
			_character = entity;
			_abilityUseNumber = entity.GetAbilityUseNumber();
			_abilityEvent = entity.GetAbilityEvent();
			_abilityEvent.Subscribe(OnAbilityUsed);
		}

		private void OnAbilityUsed()
		{
			_abilityUseNumber.Value--;
			if (_abilityUseNumber.Value <= 0)
			{
				_removeActiveAbilityEvent.Invoke();
			}
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnAbilityUsed);
		}
	}
}