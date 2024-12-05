using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;

namespace Game
{
	public sealed class AbilityPickupBehaviour : IEntityInit, IEntityDispose
	{
		private IEntity _entity;
		private ReactiveVariable<IEntityAspect> _activeAbilityAspect;
		private BaseEvent<IEntityAspect> _applyAbilityAspectRequest;

		public void Init(IEntity entity)
		{
			_entity = entity;
			_activeAbilityAspect = entity.GetActiveAbilityAspect();
			_applyAbilityAspectRequest = entity.GetApplyAbilityAspectRequest();
			_applyAbilityAspectRequest.Subscribe(OnChangeAspect);
		}

		private void OnChangeAspect(IEntityAspect aspect)
		{
			_activeAbilityAspect.Value?.Discard(_entity);
			_activeAbilityAspect.Value = aspect;
			_activeAbilityAspect.Value.Apply(_entity);
		}

		public void Dispose(IEntity entity)
		{
			_activeAbilityAspect.Unsubscribe(OnChangeAspect);
		}
	}
}