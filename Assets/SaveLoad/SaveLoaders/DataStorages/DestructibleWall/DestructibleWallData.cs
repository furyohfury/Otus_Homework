using UnityEngine;

namespace SaveLoad
{
	public sealed class DestructibleWallData
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public int InstanceId;

		public DestructibleWallData(Vector3 position, Quaternion rotation, int instanceId)
		{
			Position = position;
			Rotation = rotation;
			InstanceId = instanceId;
		}
	}
}