using System;
using Atomic.AI;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class AttackRangeAIGizmos : IAIGizmos
	{
		public void OnGizmos(IBlackboard blackboard)
		{
			Gizmos.color = Color.red;
			var attackRange = blackboard.GetAttackRange();
			var center = blackboard.GetEntity().transform.position;
			Gizmos.DrawWireSphere(center, attackRange);
		}
	}
}