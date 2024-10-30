using System;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class AssignWaypointBTNode : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			if (!blackboard.TryGetWaypoints(out var waypoints))
			{
				return BTResult.FAILURE;
			}

			var index = blackboard.GetWaypointIndex();
			var targetWaypoint = waypoints[index].gameObject;

			blackboard.SetTarget(targetWaypoint);
			return BTResult.SUCCESS;
		}
	}
}