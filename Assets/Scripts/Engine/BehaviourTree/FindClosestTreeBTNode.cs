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
				Debug.LogError("No tree service found");
				return BTResult.FAILURE;
			}

			var character = blackboard.GetCharacter();
			if (!treeService.FindClosest(character.transform.position, out var target))
			{
				return BTResult.FAILURE;
			}

			blackboard.SetTarget(target);
			return BTResult.SUCCESS;
		}
	}
}