using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class ResourceStorageIsNotEmpty : IBlackboardCondition
	{
		[SerializeField]
		private ResourceStorageComponent _resourceStorage;

		public bool Invoke(IBlackboard blackboard)
		{
			return _resourceStorage.IsNotEmpty();
		}
	}
}