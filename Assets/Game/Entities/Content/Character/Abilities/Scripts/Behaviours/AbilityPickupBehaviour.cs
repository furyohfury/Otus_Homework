using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityPickupBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _characterEntity;
		private IEvent<AbilityCardConfig> _pickupAbilityCardEvent;
		private ReactiveList<IEntityAspect> _activeAbilityAspects;

		public void Init(IEntity entity)
		{
			_characterEntity = entity;
			_activeAbilityAspects = entity.GetActiveAbilityAspects();
			_pickupAbilityCardEvent = entity.GetAbilityCardPickupEvent();
			_pickupAbilityCardEvent.Subscribe(OnChangeAspect);
		}

		private void OnChangeAspect(AbilityCardConfig abilityCardConfig)
		{
			if (_activeAbilityAspects != null)
			{
				foreach (var aspect in _activeAbilityAspects)
				{
					aspect.Discard(_characterEntity);
				}
			}

			foreach (var aspect in abilityCardConfig.Aspects)
			{
				aspect.Apply(_characterEntity);
			}

			if (_activeAbilityAspects != null)
			{
				_activeAbilityAspects.Clear();
				IEntityAspect[] cardConfigAspects = abilityCardConfig.Aspects;
				for (int i = 0; i < cardConfigAspects.Length; i++)
				{
					_activeAbilityAspects.Add(cardConfigAspects[i]);
				}
			}
		}

		public void Dispose(IEntity entity)
		{
			_pickupAbilityCardEvent.Unsubscribe(OnChangeAspect);
		}
	}
}