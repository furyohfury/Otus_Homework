using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityPickupBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _characterEntity;
		private BaseEvent<AbilityCardConfig> _pickupAbilityCardEvent;
		private ReactiveList<IEntityAspect> _activeAbilityAspects;
		private IEvent _removeActiveAbilityEvent;

		public void Init(IEntity entity)
		{
			_characterEntity = entity;
			_removeActiveAbilityEvent = entity.GetRemoveActiveAbilityEvent();
			_activeAbilityAspects = entity.GetActiveAbilityAspects();
			_pickupAbilityCardEvent = entity.GetAbilityCardPickupEvent();
			_pickupAbilityCardEvent.Subscribe(OnChangeAspect);
		}

		private void OnChangeAspect(AbilityCardConfig cardConfig)
		{
			if (_activeAbilityAspects != null)
			{
				foreach (var aspect in _activeAbilityAspects)
				{
					aspect.Discard(_characterEntity);
				}
			}

			foreach (var aspect in cardConfig.Aspects)
			{
				aspect.Apply(_characterEntity);
			}

			_activeAbilityAspects.Clear();
			IEntityAspect[] cardConfigAspects = cardConfig.Aspects;
			for (int i = 0; i < cardConfigAspects.Length; i++)
			{
				_activeAbilityAspects.Add(cardConfigAspects[i]);
			}
		}

		public void Dispose(IEntity entity)
		{
			_pickupAbilityCardEvent.Unsubscribe(OnChangeAspect);
		}
	}
}