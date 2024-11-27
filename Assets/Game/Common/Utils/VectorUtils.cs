namespace Game
{
	public static class VectorUtils
	{
		public static void LookAtX(this Transform transform, Vector3 targetPos)
		{
			var dir = targetPos - transform.position;
			var angle = Vector3.Angle(transform.right, dir);
			var rotation = Quaternion.Euler(new Vector3(angle, 0, 0));

			transform.rotation *= rotation;
		}
	}
}