namespace Game.EventBus
{
    public sealed class AttackWrongTargetEffect : IEffect
	{
		public float Probability;
		public HeroEntity CurrentHero;
		public HeroView InitialTarget;
		public HeroView[] AvailableTargets;

		public AttackWrongTargetEffect(HeroEntity currentHero, HeroView initialTarget, HeroView[] availableTargets)
		{
			CurrentHero = currentHero;
			InitialTarget = initialTarget;
			AvailableTargets = availableTargets;
		}
	}
}