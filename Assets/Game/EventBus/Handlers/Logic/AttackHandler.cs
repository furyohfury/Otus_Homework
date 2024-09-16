using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class AttackHandler : BaseHandler<AttackEvent>
	{
		[Inject]
		public AttackHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(AttackEvent evt)
		{
			Debug.Log($"Attack handled. Source: {evt.Source.gameObject.name}, Target: {evt.Target.gameObject.name}");
			evt.Source.TryGetData(out StatsComponent sourceStatsComponent);
			var sourceDamage = sourceStatsComponent.Damage;
			evt.Target.TryGetData(out StatsComponent targetStatsComponent);
			var targetDamage = targetStatsComponent.Damage;

			EventBus.RaiseEvent(new DealDamageEvent(evt.Source, evt.Target, sourceDamage));

			if (!evt.Source.HasData<NoReturnDamageComponent>())
			{
				EventBus.RaiseEvent(new DealDamageEvent(evt.Target, evt.Source, targetDamage));
			}

			if (evt.Source.HasData<FreezeOnAttackComponent>())
			{
				EventBus.RaiseEvent(new FreezeEvent(evt.Target));
			}
		}
	}
}