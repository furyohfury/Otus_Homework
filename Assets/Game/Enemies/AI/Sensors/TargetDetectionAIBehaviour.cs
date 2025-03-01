using System;
using Atomic.AI;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class TargetDetectionAIBehaviour : IAIUpdate
	{
		[SerializeField]
		private LayerMask _targetLayer;

		public void OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			var detectRange = blackboard.GetDetectRange();
			var self = blackboard.GetEntity();
			var targetCollider = Physics2D.OverlapCircle(self.transform.position,
				detectRange,
				_targetLayer);

			if (targetCollider != null && targetCollider.TryGetComponent(out Transform targetTransform))
			{
				if (blackboard.HasTarget() == false)
				{
					blackboard.SetTarget(targetTransform);
					self.SetTarget(new BaseFunction<Vector2>(() => targetTransform.position));
				}
			}
			else
			{
				blackboard.DelTarget();
				self.DelTarget();
			}
		}
	}
}