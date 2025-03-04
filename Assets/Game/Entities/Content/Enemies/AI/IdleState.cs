using System;
using Atomic.AI;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class IdleState : IState
	{
		public string Name => "IdleState";

		public void OnEnter(IBlackboard blackboard)
		{
			var self = blackboard.GetEntity();
			self.GetMoveDirection().Value = Vector2.zero;
		}

		public void OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			
		}

		public void OnExit(IBlackboard blackboard)
		{
			
		}
	}
}