using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class FindClosestTreeBTNode : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			if (!blackboard.TryGetTreeService(out var treeService))
			{
				return BTResult.FAILURE;
			}

			var character = blackboard.GetCharacter();
			if (!treeService.FindClosest(character.transform.position, out var target))
			{
				blackboard.DelTarget();
				Debug.Log("No target found");
				return BTResult.FAILURE;
			}

			blackboard.SetTarget(target);
			Debug.Log("Target found: ", target.gameObject);
			return BTResult.SUCCESS;
		}
	}
}