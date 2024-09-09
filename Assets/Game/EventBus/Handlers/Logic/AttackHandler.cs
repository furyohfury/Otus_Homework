using Entities;
using UnityEngine;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public sealed class AttackHandler : BaseHandler<AttackEvent>
	{
		[Inject]
		public AttackHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(AttackEvent evt) // TODO crutched. Fix if possible
		{
			Debug.Log($"Attack handled. Source: {evt.Source.gameObject.name}, Target: {evt.Target.gameObject.name}");
			evt.Source.TryGetData(out DamageComponent sourceDamageComponent);
			var sourceDamage = sourceDamageComponent.Damage;
			evt.Target.TryGetData(out DamageComponent targetDamageComponent);
			var targetDamage = targetDamageComponent.Damage;

			EventBus.RaiseEvent(new DealDamageEvent(evt.Target, sourceDamage));
			if (!evt.Source.HasData<NoReturnDamageComponent>())
			{
				EventBus.RaiseEvent(new DealDamageEvent(evt.Source, targetDamage));
			}
		}
	}
}