using UnityEngine;

namespace Game
{
	public static class VectorUtils
	{
		public static void LookAtX(this Transform transform, Vector3 targetPos)
		{
			Vector3 direction = targetPos - transform.position;

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			if (direction.x < 0)
			{
				transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
			else
			{
				transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), transform.localScale.z);
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
		}
	}
}