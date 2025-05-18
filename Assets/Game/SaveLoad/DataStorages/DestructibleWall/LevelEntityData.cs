using UnityEngine;

namespace SaveLoad
{
	public struct LevelEntityData
	{
		public string Id;
		public int InstanceId;
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 Scale;

		public LevelEntityData(string id, int instanceId, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Id = id;
			InstanceId = instanceId;
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}
	}
}