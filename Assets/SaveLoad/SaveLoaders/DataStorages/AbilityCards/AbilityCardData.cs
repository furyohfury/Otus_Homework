using UnityEngine;

namespace SaveLoad
{
	public struct AbilityCardData
	{
		public int InstanceID;
		public string Id;
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 Scale;

		public AbilityCardData(int instanceID, string id, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			InstanceID = instanceID;
			Id = id;
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}
	}
}