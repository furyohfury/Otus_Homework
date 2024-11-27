using UnityEngine;

namespace Game
{
	public static class VectorUtils
	{
		public static void LookAtX(this Transform transform, Vector3 target)
		{
			// Направление от объекта к цели
			Vector3 direction = target - transform.position;

			// Угол в градусах для поворота вокруг оси Z
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			// Устанавливаем поворот
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}
}