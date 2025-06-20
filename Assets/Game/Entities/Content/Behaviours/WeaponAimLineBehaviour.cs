using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class WeaponAimLineBehaviour : IEntityInit, IEntityLateUpdate
	{
		private LineRenderer _aimLine;

		public void Init(IEntity entity)
		{
			_aimLine = entity.GetAimLine();
		}

		public void OnLateUpdate(IEntity entity, float deltaTime)
		{
			if (entity.TryGetTarget(out IFunction<Vector2> target) == false
			    || entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon) == false
			    || weapon.Value.TryGetFirePoint(out ReactiveVariable<Transform> firePoint) == false)
			{
				_aimLine.enabled = false;
				return;
			}

			_aimLine.enabled = true;
			var firePointPosition = firePoint.Value.position + firePoint.Value.right * 0.1f;
			_aimLine.SetPosition(0, firePointPosition);
			_aimLine.SetPosition(1, target.Invoke());
		}
	}
}