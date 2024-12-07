using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class RemoveActiveAbilityBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _character;
		private ReactiveVariable<IEntityAspect[]> _activeAbilityAspects;
		private BaseEvent _removeActiveAbilityEvent;

		public void Init(IEntity entity)
		{
			_character = entity;
			_activeAbilityAspects = entity.GetActiveAbilityAspects();
			_removeActiveAbilityEvent = entity.GetRemoveActiveAbilityEvent();
			_removeActiveAbilityEvent.Subscribe(OnRemoveActiveAbility);
		}

		private void OnRemoveActiveAbility()
		{
			foreach (var aspect in _activeAbilityAspects.Value)
			{
				aspect.Discard(_character);
			}

			_activeAbilityAspects.Value = null;
		}

		public void Dispose(IEntity entity)
		{
			_removeActiveAbilityEvent.Unsubscribe(OnRemoveActiveAbility);
		}
	}
}