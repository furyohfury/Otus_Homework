using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "CursorSpritesConfig", menuName = "Create config/UI/CursorSpritesConfig")]
	public sealed class CursorSpritesConfig : SerializedScriptableObject
	{
		public Dictionary<CursorState, Sprite> Sprites;
	}
}