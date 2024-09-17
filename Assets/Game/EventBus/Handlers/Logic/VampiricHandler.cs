using Zenject;
using Random = UnityEngine.Random;

namespace EventBus
{
	public sealed class VampiricHandler : BaseHandler<VampiricEvent>
	{
		[Inject]
		public VampiricHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(VampiricEvent evt)
		{
			if (Random.value > evt.Probability)
			{
				return;
			}

			EventBus.RaiseEvent(new HealEvent(evt.Entity, evt.Damage));
		}
	}
}