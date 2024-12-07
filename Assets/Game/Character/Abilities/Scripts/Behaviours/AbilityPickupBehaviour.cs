using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityPickupBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _characterEntity;
		private BaseEvent<AbilityCardConfig> _pickupAbilityCardEvent;
		private ReactiveVariable<IEntityAspect[]> _activeAbilityAspects;

		public void Init(IEntity entity)
		{
			_characterEntity = entity;
			_activeAbilityAspects = entity.GetActiveAbilityAspects();
			_pickupAbilityCardEvent = entity.GetAbilityCardPickupEvent();
			_pickupAbilityCardEvent.Subscribe(OnChangeAspect);
		}

		private void OnChangeAspect(AbilityCardConfig cardConfig)
		{
			if (_activeAbilityAspects.Value != null)
			{
				foreach (var aspect in _activeAbilityAspects.Value)
				{
					aspect.Discard(_characterEntity);
				}
			}
			
			foreach (var aspect in cardConfig.Aspects)
			{
				aspect.Apply(_characterEntity);
			}

			_activeAbilityAspects.Value = cardConfig.Aspects;
		}

		public void Dispose(IEntity entity)
		{
			_pickupAbilityCardEvent.Unsubscribe(OnChangeAspect);
		}
	}
}