using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "Create WeaponConfig", fileName = "WeaponConfig")]
	public sealed class WeaponConfig : ScriptableObject
	{
		public SceneEntity ProjectilePrefab => _projectilePrefab;
		public GameObject WeaponPrefab => _weaponPrefab;
		public float ShootDelay => _shootDelay;
		public float SpreadAngle => _spreadAngle;

		[SerializeField]
		private SceneEntity _projectilePrefab;
		[SerializeField]
		private GameObject _weaponPrefab;
		[SerializeField]
		private float _shootDelay;
		[SerializeField]
		private float _spreadAngle;
	}
}