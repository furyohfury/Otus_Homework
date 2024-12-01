using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "Create WeaponConfig", fileName = "WeaponConfig")]
	public sealed class WeaponConfig : ScriptableObject
	{
		public GameObject ProjectilePrefab => _projectilePrefab;
		public GameObject WeaponPrefab => _weaponPrefab;
		public float ShootDelay => _shootDelay;
		public float SpreadAngle => _spreadAngle;

		[SerializeField]
		private GameObject _projectilePrefab;
		[SerializeField]
		private GameObject _weaponPrefab;
		[SerializeField]
		private float _shootDelay;
		[SerializeField]
		private float _spreadAngle;
	}
}