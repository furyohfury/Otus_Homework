using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class MoveToTargetBTNode : BTNode
	{
		[SerializeField] [BlackboardKey]
		private int targetKey;

		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			if (!blackboard.TryGetCharacter(out var character) ||
			    !blackboard.TryGetObject(targetKey, out GameObject target) ||
			    !blackboard.TryGetStoppingDistance(out var stoppingDistance))
			{
				return BTResult.FAILURE;
			}

			var distanceVector = target.transform.position - character.transform.position;
			distanceVector.y = 0;

			if (distanceVector.sqrMagnitude <= stoppingDistance * stoppingDistance)
			{
				return BTResult.SUCCESS;
			}

			var moveDirection = distanceVector.normalized;
			character.GetComponent<MoveComponent>().MoveStep(moveDirection);
			return BTResult.RUNNING;
		}
	}
}