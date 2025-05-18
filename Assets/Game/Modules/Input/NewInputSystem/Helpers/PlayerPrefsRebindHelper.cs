using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "PlayerPrefsRebindHelper", menuName = "Create helper/PlayerPrefsRebindHelper")]
	public sealed class PlayerPrefsRebindHelper : ScriptableObject
	{
		[SerializeField]
		private string _key;

		[Button]
		private void ClearRebindPrefs()
		{
			if (PlayerPrefs.HasKey(_key))
			{
				PlayerPrefs.DeleteKey(_key);
			}
			else
			{
				Debug.Log($"No key: {_key} in player prefs");
			}
		}
	}
}