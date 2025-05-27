using Atomic.AI;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AttackState : IState
	{
		public string Name => "AttackState";

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
				if (_self.TryGetMoveDirection(out ReactiveVariable<Vector2> moveDirection))
				{
					moveDirection.Value = Vector2.zero;
				}

				_attackRequest.Invoke();
			}
			else
			{
				if (_self.TryGetMoveDirection(out ReactiveVariable<Vector2> moveDirection))
				{
					direction.Normalize();
					moveDirection.Value = new Vector2(direction.x, 0);
				}
			}
		}

		public void OnExit(IBlackboard blackboard)
		{
		}
	}
}