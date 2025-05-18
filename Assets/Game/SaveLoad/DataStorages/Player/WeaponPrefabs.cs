using System.Collections.Generic;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "WeaponPrefabs", menuName = "Create saveload config/Create weapon prefabs")]
	public sealed class WeaponPrefabs : SerializedScriptableObject
	{
		public Dictionary<string, SceneEntity> Prefabs;
	}
}