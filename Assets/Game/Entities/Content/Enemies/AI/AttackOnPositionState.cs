using Atomic.AI;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AttackOnPositionState : IState
	{
		public string Name => "AttackOnPositionState";

		private IEvent _attackRequest;
		private SceneEntity _self;
		private float _attackRange;

		public void OnEnter(IBlackboard blackboard)
		{
			if (blackboard.TryGetEntity(out var self))
			{
				_attackRequest = self.GetAttackRequest();
				_self = self;
			}

			_attackRange = blackboard.GetAttackRange();
		}

		public void OnUpdate(IBlackboard blackboard, float deltaTime)
		{
			var target = blackboard.GetTarget();
			var direction = target.transform.position - _self.transform.position;
			var targetInRange = direction.sqrMagnitude <= _attackRange * _attackRange;
			if (targetInRange)
			{
				_attackRequest.Invoke();
			}
		}

		public void OnExit(IBlackboard blackboard)
		{
		}
	}
}