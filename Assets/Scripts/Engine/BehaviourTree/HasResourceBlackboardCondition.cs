using System;
using Atomic.AI;

namespace Game.Engine
{
	[Serializable]
	public sealed class HasResourceBlackboardCondition : IBlackboardCondition
	{
		public bool Invoke(IBlackboard blackboard)
		{
			return blackboard.GetCharacter().GetComponent<ResourceStorageComponent>().IsNotEmpty();
		}
	}
}