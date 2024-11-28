using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class RotateToTarget2DBehaviour : IEntityInit, IEntityUpdate
	{
		private Transform _entityTransform;
		private SpriteRenderer _spriteRenderer;
		private bool _isLookingRight = true;

		public void Init(IEntity entity)
		{
			_entityTransform = entity.GetVisualTransform();
			_spriteRenderer = entity.GetSpriteRenderer();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!entity.TryGetTarget(out var targetPos))
			{
				return;
			}
			
			float delta = targetPos.Invoke().x - _entityTransform.position.x;
			if (delta >= 0 && _isLookingRight || delta < 0 && !_isLookingRight)
			{
				return;
			}

			if (delta >= 0)
			{
				// _entityTransform.eulerAngles = Vector3.zero;
				_spriteRenderer.flipX = false;
				_isLookingRight = true;
			}
			else
			{
				// _entityTransform.eulerAngles = new Vector3(0, 180, 0);
				_spriteRenderer.flipX = true;
				_isLookingRight = false;
			}
		}
	}
}