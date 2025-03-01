using Atomic.AI;

namespace Game
{
	public sealed class HasTargetBlackboardCondition : IBlackboardCondition
	{
		public bool Invoke(IBlackboard blackboard)
		{
			return blackboard.HasTarget();
		}
	}
}