using Atomic.AI;

namespace Game.Engine
{
	public sealed class WaypointPauseBTNode : BTNode
	{
		protected override void OnEnable(IBlackboard blackboard)
		{
			var duration = blackboard.GetWaypointPause();
			blackboard.SetWaypointTime(duration);
		}

		protected override void OnDisable(IBlackboard blackboard)
		{
			blackboard.DelWaypointTime();
		}

		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			var remainingTime = blackboard.GetWaypointTime();
			remainingTime -= deltaTime;
			blackboard.SetWaypointTime(remainingTime);

			return remainingTime <= 0
				? BTResult.SUCCESS
				: BTResult.RUNNING;
		}
	}
}