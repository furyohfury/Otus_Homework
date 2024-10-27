using System;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class HasTargetBlackboardCondition : IBlackboardCondition
	{
		public bool Invoke(IBlackboard blackboard)
		{
			return blackboard.TryGetTarget(out _);
		}
	}
}