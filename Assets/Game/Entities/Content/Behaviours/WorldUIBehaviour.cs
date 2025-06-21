using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class WorldUIBehaviour : IEntityInit, IEntityLateUpdate
	{
		private GameObject _entityWorldUI;
		private Transform _visualTransform;

		private bool _cachedDirection;

		public void Init(IEntity entity)
		{
			_entityWorldUI = entity.GetEntityWorldUI();
			_visualTransform = entity.GetVisualTransform();
			_cachedDirection = _visualTransform.localScale.x > 0;
		}

		public void OnLateUpdate(IEntity entity, float deltaTime)
		{
			var activeDirection = _visualTransform.localScale.x > 0;
			if (_cachedDirection == activeDirection)
			{
				return;
			}

			var scale = _entityWorldUI.transform.localScale;
			_entityWorldUI.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
			_cachedDirection = activeDirection;
		}
	}
}