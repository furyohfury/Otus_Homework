using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityUseNumberBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _entity;
		private BaseEvent _abilityEvent;
		private ReactiveVariable<int> _abilityUseNumber;
		private ReactiveVariable<IEntityAspect> _activeAbilityAspect;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_abilityUseNumber = entity.GetAbilityUseNumber();
			_activeAbilityAspect = entity.GetActiveAbilityAspect();
			_abilityEvent = entity.GetAbilityEvent();
			_abilityEvent.Subscribe(OnAbilityUsed);
		}

		private void OnAbilityUsed()
		{
			_abilityUseNumber.Value--;
			if (_abilityUseNumber.Value <= 0)
			{
				_entity.DiscardAspect(_activeAbilityAspect.Value);
				_activeAbilityAspect.Value = null;
			}
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnAbilityUsed);
		}
	}
}