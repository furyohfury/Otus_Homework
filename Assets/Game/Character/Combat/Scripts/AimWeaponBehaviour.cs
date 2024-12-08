using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AimWeaponBehaviour : IEntityUpdate, IEntityEnable, IEntityDisable
	{
		private bool _isActive = true;
		
		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (!_isActive)
			{
				return;
			}
			
			if (!entity.TryGetTarget(out IFunction<Vector2> target)
			    || !entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				return;
			}

			var weaponTransform = weapon.Value.GetVisualTransform();
			weaponTransform.LookAtX(target.Invoke());
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