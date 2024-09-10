namespace Game.EventBus
{
public sealed class WrongTargetEffectHandler : BaseHandler<AttackWrongTargetEffect>
	{
		protected override void OnHandleEvent(AttackWrongTargetEffect evt)
         {
			if (Random.value > evt.Probability && AvailableTargets.Length <= 1)
			{
				_eventBus.RaiseEvent(new AttackEvent(currentHero, InitialTarget.GetComponent<HeroEntity>()));
			}
			else
			{
				HeroView newTarget;
				do
				{
					int index = Random.Range(0, AvailableTargets.Length - 1);
					newTarget = AvailableTargets[index];
				} while (newTarget != InitialTarget);

				_eventBus.RaiseEvent(new AttackEvent(currentHero, newTarget.GetComponent<HeroEntity>()));
			}
		 }
	}
}