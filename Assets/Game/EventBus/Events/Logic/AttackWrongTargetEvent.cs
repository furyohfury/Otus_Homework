using System;
using Entities;

namespace EventBus
{
	[Serializable]
	public struct AttackWrongTargetEvent : IEvent
	{
		public float Probability;
		public HeroEntity InitialTarget;

		public AttackWrongTargetEvent(float probability, HeroEntity initialTarget)
		{
			Probability = probability;
			InitialTarget = initialTarget;
		}
	}
}