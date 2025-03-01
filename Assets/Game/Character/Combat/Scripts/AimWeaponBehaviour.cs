using System;
using Atomic.Elements;
using Atomic.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
	public sealed class AimWeaponBehaviour : IEntityUpdate
	{
		public void OnUpdate(IEntity entity, float deltaTime)
		{

			if (entity.TryGetTarget(out IFunction<Vector2> target) == false
			    || entity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon) == false)
			{
				return;
			}

			var weaponTransform = weapon.Value.GetVisualTransform();
			Vector2 targetPos = target.Invoke();
			Vector2 weaponPos = weaponTransform.position;
			Vector2 weaponScale = weaponTransform.localScale;

			// Вычисляем направление к цели
			Vector2 direction = (targetPos - weaponPos).normalized;
			var sign = Mathf.Sign(targetPos.x - weaponPos.x);
			if (sign > 0)
			{
				weaponTransform.localScale = new Vector2(Math.Abs(weaponScale.x), Math.Abs(weaponScale.y));
			}
			else
			{
				weaponTransform.localScale = new Vector2(-Math.Abs(weaponScale.x), -Math.Abs(weaponScale.y));
			}

			// Вычисляем угол вращения в градусах
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			// Поворачиваем оружие по оси Z
			weaponTransform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}