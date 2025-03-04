using System;
using Atomic.AI;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class PatrolOnPositionState : IState
	{
		public string Name => "PatrolOnPositionState";

		[SerializeField]
		private LayerMask _targetLayer;
		private float _attackRange;
		private SceneEntity _self;

		public void OnEnter(IBlackboard blackboard)
		{
			_attackRange = blackboard.GetAttackRange();
			_self = blackboard.GetEntity();
		}

		public void OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			var targetCollider = Physics2D.OverlapCircle(_self.transform.position,
				_attackRange,
				_targetLayer);

			if (targetCollider != null && targetCollider.TryGetComponent(out SceneEntityProxy targetEntity))
			{
				// blackboard.SetTarget(targetEntity.source);
			}
		}

		public void OnExit(IBlackboard blackboard)
		{
		}
	}
}