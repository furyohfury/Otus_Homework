using System.Collections.Generic;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "LevelEntitiesPrefabs", menuName = "Create config/LevelEntitiesPrefabs")]
	public sealed class LevelEntitiesPrefabs : SerializedScriptableObject
	{
		public Dictionary<string, SceneEntity> Prefabs;
	}
}