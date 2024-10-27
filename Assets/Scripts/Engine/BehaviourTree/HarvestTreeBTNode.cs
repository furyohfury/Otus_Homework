using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class HarvestTreeBTNode : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			HarvestComponent harvestComponent = blackboard.GetCharacter().GetComponent<HarvestComponent>();
			ResourceStorageComponent resourceStorageComponent = blackboard.GetCharacter().GetComponent<ResourceStorageComponent>();

			GameObject tree = blackboard.GetTreeTarget();

			// if (!tree.activeInHierarchy && resourceStorageComponent.IsNotEmpty())
			// {
			// 	return BTResult.FAILURE;
			// }
            
			if (resourceStorageComponent.IsEmpty() && tree.activeInHierarchy)
			{
				harvestComponent.StartHarvest();
				return BTResult.RUNNING;
			}
			return BTResult.SUCCESS;
		}
	}
}