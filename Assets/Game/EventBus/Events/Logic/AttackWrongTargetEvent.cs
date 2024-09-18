using Entities;

namespace EventBus
{
	public struct AttackWrongTargetEvent : IEvent
	{
		public readonly float Probability;
		public readonly Entity InitialTarget;

		public AttackWrongTargetEvent(float probability, Entity initialTarget)
		{
			Probability = probability;
			InitialTarget = initialTarget;
		}
	}
}