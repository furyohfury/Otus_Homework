using UnityEngine;

namespace SaveLoad
{
	public sealed class EnemyData
	{
		public int InstanceId;
		public string Id;
		public Vector3 Position;
		public Quaternion Rotation;
		public int Health;

		public EnemyData(int instanceId, string id, Vector3 position, Quaternion rotation, int health)
		{
			InstanceId = instanceId;
			Id = id;
			Position = position;
			Rotation = rotation;
			Health = health;
		}
	}
}