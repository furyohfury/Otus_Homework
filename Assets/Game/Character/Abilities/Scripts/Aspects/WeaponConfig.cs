using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "Create config", fileName = "Weapon config")]
	public sealed class WeaponConfig : ScriptableObject
	{
		public SceneEntity ProjectilePrefab => _projectilePrefab;
		public GameObject WeaponPrefab => _weaponPrefab;
		public float ShootDelay => _shootDelay;
		public int Damage => _damage;
		public float SpreadAngle => _spreadAngle;
		public int AmmoSize => _ammoSize;

		[SerializeField]
		private SceneEntity _projectilePrefab;
		[SerializeField]
		private GameObject _weaponPrefab;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private float _shootDelay;
		[SerializeField]
		private float _spreadAngle;
		[SerializeField]
		private int _ammoSize;
	}
}