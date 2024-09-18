using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class RemoveFrozenHandler : BaseHandler<RemoveFrozenEvent>
	{
		[Inject]
		public RemoveFrozenHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(RemoveFrozenEvent evt)
		{
			Debug.Log($"RemoveFrozenHandler.Target: {evt.Target.gameObject.name}");
			evt.Target.RemoveData<FrozenComponent>();
		}
	}
}