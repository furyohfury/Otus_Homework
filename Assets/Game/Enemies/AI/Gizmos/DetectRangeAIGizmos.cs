using System;
using Atomic.AI;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class DetectRangeAIGizmos : IAIGizmos
	{
		public void OnGizmos(IBlackboard blackboard)
		{
			Gizmos.color = Color.yellow;
			var detectRange = blackboard.GetDetectRange();
			var center = blackboard.GetEntity().transform.position;
			Gizmos.DrawWireSphere(center, detectRange);
		}
	}
}