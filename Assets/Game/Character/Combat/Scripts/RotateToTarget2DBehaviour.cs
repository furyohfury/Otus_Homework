using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class RotateToTarget2DBehaviour : IEntityInit, IEntityUpdate, IEntityEnable, IEntityDisable
	{
		private Transform _entityTransform;
		private SpriteRenderer _spriteRenderer;
		private bool _isLookingRight = true;
		private bool _isActive = true;

		public void Init(IEntity entity)
		{
			_entityTransform = entity.GetVisualTransform();
			_spriteRenderer = entity.GetSpriteRenderer();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}
			
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
				_spriteRenderer.flipX = false;
				_isLookingRight = true;
			}
			else
			{
				_spriteRenderer.flipX = true;
				_isLookingRight = false;
			}
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