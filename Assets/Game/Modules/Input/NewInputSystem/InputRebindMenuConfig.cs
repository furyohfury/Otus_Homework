using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "InputRebindConfig", menuName = "Create config/InputRebindConfig")]
	public sealed class InputRebindMenuConfig : ScriptableObject
	{
		public string Scheme;

		public InputActionsUIData[] Data;
	}
}