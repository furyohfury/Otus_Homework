using System;
using UnityEngine.Serialization;

namespace Game
{
	[Serializable]
	public struct InputActionsUIData
	{
		public string Action;
		[FormerlySerializedAs("Path")] 
		public string DefaultPath;
		public string ActionDisplayName;
	}
}