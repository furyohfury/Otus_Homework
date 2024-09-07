using Entities;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
	public sealed class AttackHandler : BaseHandler<AttackEvent>
	{
		public AttackHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(AttackEvent evt) // TODO crutched. Fix if possible
		{
			Debug.Log($"Attack handled. Source: {evt.Source.gameObject.name}, Target: {evt.Target.gameObject.name}");
			var sourceDamage = 0;
			var targetDamage = 0;
			if (evt.Source.TryGetData(out DamageComponent sourceDamageComponent))
			{
				sourceDamage = sourceDamageComponent.Damage;
				if (evt.Target.TryGetData(out DamageComponent targetDamageComponent))
				{
					targetDamage = targetDamageComponent.Damage;
				}
			}

			EventBus.RaiseEvent(new DealDamageEvent(evt.Target, sourceDamage));
			EventBus.RaiseEvent(new DealDamageEvent(evt.Source, targetDamage));
		}
	}
}