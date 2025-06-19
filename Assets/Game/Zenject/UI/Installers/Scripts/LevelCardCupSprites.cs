using System.Collections.Generic;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI
{
	[CreateAssetMenu(fileName = "LevelCardCupSprites", menuName = "Create config/Level/LevelCardCupSprites")]
	public sealed class LevelCardCupSprites : SerializedScriptableObject
	{
		public Dictionary<Cups, Sprite> CupSprites => _cupSprites;

		[SerializeField]
		private Dictionary<Cups, Sprite> _cupSprites;
	}
}