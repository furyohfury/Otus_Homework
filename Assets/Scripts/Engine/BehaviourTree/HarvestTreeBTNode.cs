using System;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class HarvestTreeBTNode : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			if (!blackboard.TryGetCharacter(out var character) || !blackboard.TryGetTarget(out var tree))
			{
				return BTResult.FAILURE;
			}

			if ((tree.transform.position - character.transform.position).sqrMagnitude > 1)
			{
				return BTResult.FAILURE;
			}

			var harvestComponent = character.GetComponent<HarvestComponent>();
			var resourceStorageComponent = character.GetComponent<ResourceStorageComponent>();

			if (resourceStorageComponent.IsNotFull() && tree.activeInHierarchy)
			{
				harvestComponent.StartHarvest();
				return BTResult.RUNNING;
			}

			return BTResult.SUCCESS;
		}
	}
}