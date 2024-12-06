using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AimWeaponBehaviour : IEntityUpdate
	{
		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!entity.TryGetTarget(out IFunction<Vector2> target)
			    || !entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				return;
			}

			var weaponTransform = weapon.Value.GetVisualTransform();
			weaponTransform.LookAtX(target.Invoke());
		}
	}
}