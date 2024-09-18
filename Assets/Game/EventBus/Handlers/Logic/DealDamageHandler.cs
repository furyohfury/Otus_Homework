using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
	{
		[Inject]
		public DealDamageHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(DealDamageEvent evt)
		{
			if (!evt.Target.TryGetData(out StatsComponent statsComponent))
			{
				return;
			}

			if (evt.Target.HasData<DivineShieldComponent>())
			{
				EventBus.RaiseEvent(new RemoveDivineShieldEvent(evt.Target));
				return;
			}

			Debug.Log($"DealDamage handled. Target: {evt.Target.gameObject.name}, damage: {evt.Damage}");
			statsComponent.CurrentHealth -= evt.Damage;

			if (evt.Target.TryGetData(out DamagedEventsComponent damagedEventsComponent))
			{
				foreach (var damagedEvent in damagedEventsComponent.Events)
				{
					damagedEvent.Source = evt.Target;
					EventBus.RaiseEvent(damagedEvent);
				}
			}

			if (evt.Source.TryGetData(out VampiricComponent vampiricComponent))
			{
				EventBus.RaiseEvent(new VampiricEvent(evt.Source, evt.Damage, vampiricComponent.Probability));
			}

			if (statsComponent.CurrentHealth <= 0)
			{
				EventBus.RaiseEvent(new DestroyEvent(evt.Target));
			}
		}
	}
}