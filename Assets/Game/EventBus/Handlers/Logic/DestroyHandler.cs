using Entities;
using UnityEngine;

namespace EventBus
{
	public sealed class DestroyHandler : BaseHandler<DestroyEvent>
	{
		public DestroyHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(DestroyEvent evt)
		{
			Debug.Log($"Destroy handled, Target: {evt.Target}");
			if (evt.Target.TryGetData(out DestroyComponent destroyComponent))
			{
				destroyComponent.Destroy();
			}
		}
	}
}