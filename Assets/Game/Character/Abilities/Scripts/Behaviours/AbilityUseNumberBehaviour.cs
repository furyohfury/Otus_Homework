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
		private ReactiveVariable<IEntityAspect[]> _activeAbilityAspects;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_abilityUseNumber = entity.GetAbilityUseNumber();
			_activeAbilityAspects = entity.GetActiveAbilityAspects();
			_abilityEvent = entity.GetAbilityEvent();
			_abilityEvent.Subscribe(OnAbilityUsed);
		}

		private void OnAbilityUsed()
		{
			_abilityUseNumber.Value--;
			if (_abilityUseNumber.Value <= 0)
			{
				foreach (var aspect in _activeAbilityAspects.Value)
				{
					aspect.Discard(_entity);
				}
				_activeAbilityAspects.Value = null;
			}
		}

		public void Dispose(IEntity entity)
		{
			_abilityEvent.Unsubscribe(OnAbilityUsed);
		}
	}
}