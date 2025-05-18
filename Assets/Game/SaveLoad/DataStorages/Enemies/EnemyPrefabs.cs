using System.Collections.Generic;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "EnemyPrefabs", menuName = "Create saveload config/Enemy prefabs config")]
	public sealed class EnemyPrefabs : SerializedScriptableObject
	{
		public Dictionary<string, SceneEntity> Prefabs => _enemyPrefabs;

		[SerializeField]
		private Dictionary<string, SceneEntity> _enemyPrefabs;
	}
}