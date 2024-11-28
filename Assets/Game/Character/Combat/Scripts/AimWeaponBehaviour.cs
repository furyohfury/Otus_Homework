using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AimWeaponBehaviour : IEntityInit, IEntityUpdate
	{
		private IValue<GameObject> _weapon;

		public void Init(IEntity entity)
		{
			_weapon = entity.GetWeapon();
		}

		public void OnUpdate(IEntity entity, float deltaTime)
		{
			if (entity.TryGetTarget(out var target) == false)
			{
				return;
			}

			var weaponTransform = _weapon.Value.transform;
			weaponTransform.LookAtX(target.Invoke());
		}
	}
}