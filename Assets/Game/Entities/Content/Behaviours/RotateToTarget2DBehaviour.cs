using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class RotateToTarget2DBehaviour : IEntityInit, IEntityUpdate, IEntityEnable, IEntityDisable
	{
		private Transform _entityTransform;
		private bool _isActive = true;

		public void Init(IEntity entity)
		{
			_entityTransform = entity.GetVisualTransform();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}

			if (!entity.TryGetTarget(out var target))
			{
				return;
			}

			Vector2 targetPos = target.Invoke();
			var direction = Mathf.Sign(targetPos.x - _entityTransform.position.x);

			Vector3 scale = _entityTransform.localScale;
			if (direction > 0 && scale.x < 0)
			{
				scale.x = Mathf.Abs(scale.x);
			}
			else if (direction < 0 && scale.x > 0)
			{
				scale.x = -Mathf.Abs(scale.x);
			}

			_entityTransform.localScale = scale;
		}

		public void Enable(IEntity entity)
		{
			_isActive = true;
		}

		public void Disable(IEntity entity)
		{
			_isActive = false;
		}
	}
}