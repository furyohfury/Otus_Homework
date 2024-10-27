using System;
using System.Linq;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class HasTreesAvailableBlackboardCondition : IBlackboardCondition
	{
		public bool Invoke(IBlackboard blackboard)
		{
			return blackboard.TryGetTreeService(out var treeService) &&
			       treeService.Trees.Any(tree => tree.activeInHierarchy);
		}
	}
}