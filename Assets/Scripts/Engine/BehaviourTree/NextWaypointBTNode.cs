using System;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class NextWaypointBTNode : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			var waypoints = blackboard.GetWaypoints();
			var index = blackboard.GetWaypointIndex();
			index = (index + 1) % waypoints.Length;

			blackboard.SetWaypointIndex(index);
			return BTResult.SUCCESS;
		}
	}
}