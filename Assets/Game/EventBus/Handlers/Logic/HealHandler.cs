using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class HealHandler : BaseHandler<HealEvent>
	{
		[Inject]
		public HealHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(HealEvent evt)
		{
			if (!evt.Entity.TryGetData(out StatsComponent stats))
			{
				return;
			}

			stats.CurrentHealth = Mathf.Min(stats.CurrentHealth + evt.Amount, stats.MaxHealth);
		}
	}
}