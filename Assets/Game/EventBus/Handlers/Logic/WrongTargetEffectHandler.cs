using Entities;
using UI;
using UnityEngine;
using Zenject;

namespace EventBus
{
public sealed class WrongTargetEffectHandler : BaseHandler<AttackWrongTargetEffect>
	{
		[Inject]
		public WrongTargetEffectHandler(EventBus eventBus) : base(eventBus)
		{
		}
		protected override void OnHandleEvent(AttackWrongTargetEffect evt)
         {
			if (Random.value > evt.Probability && evt.AvailableTargets.Length <= 1)
			{
				EventBus.RaiseEvent(new AttackEvent(evt.CurrentHero, evt.InitialTarget.GetComponent<HeroEntity>()));
			}
			else
			{
				HeroView newTarget;
				do
				{
					int index = Random.Range(0, evt.AvailableTargets.Length - 1);
					newTarget = evt.AvailableTargets[index];
				} while (newTarget != evt.InitialTarget);

				EventBus.RaiseEvent(new AttackEvent(evt.CurrentHero, newTarget.GetComponent<HeroEntity>()));
			}
		 }
	}
}