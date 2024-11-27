using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class LookAtTargetBehaviour : IEntityInit, IEntityUpdate
	{
		private Transform _entityTransform;
		private bool _isLookingRight = true;

		public void Init(IEntity entity)
		{
			_entityTransform = entity.GetVisualTransform();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!entity.TryGetTarget(out ReactiveVariable<Transform> targetTransform))
			{
				return;
			}
			
			Vector3 targetPos = targetTransform.Value.position;
			float delta = targetPos.x - _entityTransform.position.x;
			if (delta >= 0 && _isLookingRight || delta < 0 && !_isLookingRight)
			{
				return;
			}

			if (delta >= 0)
			{
				_entityTransform.eulerAngles = Vector3.zero;
				_isLookingRight = true;
			}
			else
			{
				_entityTransform.eulerAngles = new Vector3(0, 180, 0);
				_isLookingRight = false;
			}
		}
	}
}