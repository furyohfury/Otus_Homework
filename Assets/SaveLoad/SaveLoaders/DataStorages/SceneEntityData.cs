using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
	public struct SceneEntityData
	{
		public int InstanceId;
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 Scale;
		public Dictionary<int, object> State; // TODO need to save types

		public SceneEntityData(int instanceId, Vector3 position, Quaternion rotation, Vector3 scale, Dictionary<int, object> state)
		{
			InstanceId = instanceId;
			Position = position;
			Rotation = rotation;
			Scale = scale;
			State = state;
		}
	}
}