using System;
using Atomic.AI;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class ResourceStorageIsNotEmpty : IBlackboardCondition
	{
		[SerializeField] [BlackboardKey]
		private int _owner;

		public bool Invoke(IBlackboard blackboard)
		{
			if (!blackboard.TryGetObject(_owner, out GameObject ownerGo))
			{
				return false;
			}

			var storage = ownerGo.GetComponent<ResourceStorageComponent>();
			return storage.IsNotEmpty();
		}
	}
}