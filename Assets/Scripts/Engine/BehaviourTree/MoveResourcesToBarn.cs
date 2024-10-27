using System;
using Atomic.AI;
using Game.Content;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class MoveResourcesToBarn : BTNode
	{
		protected override BTResult OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			if (!blackboard.TryGetCharacter(out GameObject character))
			{
				return BTResult.FAILURE;
			}

			if (!blackboard.TryGetBarn(out var barn))
			{
				return BTResult.FAILURE;
			}
			
			var characterStorage = character.GetComponent<ResourceStorageComponent>();
			var barnStorage = barn.GetComponent<ResourceStorageComponent>();

			return MoveResources(characterStorage, barnStorage);
		}

		private static BTResult MoveResources(ResourceStorageComponent fromStorage, ResourceStorageComponent toStorage)
		{
			// if (toStorage.FreeSlots == 0)
			// {
			// 	return BTResult.FAILURE;
			// }

			var resourcesToAdd = Math.Min(toStorage.FreeSlots, fromStorage.Current);
			fromStorage.RemoveResources(resourcesToAdd);
			toStorage.AddResources(resourcesToAdd);

			return BTResult.SUCCESS;
		}
	}
}