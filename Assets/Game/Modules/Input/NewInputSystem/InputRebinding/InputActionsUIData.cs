using System;
using UnityEngine.Serialization;

namespace Game
{
	[Serializable]
	public struct InputActionsUIData
	{
		public string Action;
		public string DefaultPath;
		public string ActionDisplayName;
	}
}