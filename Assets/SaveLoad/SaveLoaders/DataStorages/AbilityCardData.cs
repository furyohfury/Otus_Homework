using UnityEngine;

namespace SaveLoad
{
	public struct AbilityCardData
	{
		public int InstanceID;
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 Scale;
		public string AssetGuid;

		public AbilityCardData(int instanceID, Vector3 position, Quaternion rotation, Vector3 scale, string assetGuid)
		{
			InstanceID = instanceID;
			Position = position;
			Rotation = rotation;
			Scale = scale;
			AssetGuid = assetGuid;
		}
	}
}