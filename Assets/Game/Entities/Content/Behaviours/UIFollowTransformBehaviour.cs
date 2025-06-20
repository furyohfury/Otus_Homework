using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class UIFollowTransformBehaviour : IEntityInit, IEntityLateUpdate
	{
		private GameObject _entityWorldUI;
		private Transform _visualTransform;
		private Vector3 _offset;

		public void Init(IEntity entity)
		{
			_entityWorldUI = entity.GetEntityWorldUI();
			_visualTransform = entity.GetVisualTransform();
			_offset = _entityWorldUI.transform.position - _visualTransform.position;
		}

		public void OnLateUpdate(IEntity entity, float deltaTime)
		{
			_entityWorldUI.transform.position = _visualTransform.position + _offset;
		}
	}
}