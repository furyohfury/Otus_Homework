using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "InputMap", menuName = "Create InputMap")]
	public sealed class InputMap : SerializedScriptableObject
	{
		public InputData[] Data => _inputData;

		[SerializeField]
		private InputData[] _inputData;
	}
}