using System;
using Atomic.AI;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class PatrolState : IState
	{
		public string Name => "PatrolState";

		private SceneEntity _self;
		private Transform[] _waypoints;
		private float _stoppingDistance;

		public void OnEnter(IBlackboard blackboard)
		{
			_self = blackboard.GetEntity();
			_waypoints = blackboard.GetWaypoints();
			_stoppingDistance = blackboard.GetStoppingDistance();
		}

		public void OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			int waypointIndex = blackboard.GetWaypointIndex();
			Vector2 myPosition = _self.transform.position;
			Vector2 targetPosition = _waypoints[waypointIndex].position;
			Vector2 distanceVector = targetPosition - myPosition;
			bool waypointReached = distanceVector.sqrMagnitude <= _stoppingDistance * _stoppingDistance;
			if (waypointReached)
			{
				waypointIndex = (waypointIndex + 1) % _waypoints.Length;
				blackboard.SetWaypointIndex(waypointIndex);
			}
			else
			{
				_self.GetMoveDirection().Value = distanceVector;
			}
		}

		public void OnExit(IBlackboard blackboard)
		{
			SceneEntity self = blackboard.GetEntity();
			self.GetMoveDirection().Value = Vector2.zero;
		}
	}
}