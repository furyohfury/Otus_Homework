using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "Create WeaponConfig", fileName = "WeaponConfig")]
	public sealed class WeaponConfig : ScriptableObject
	{
		public GameObject ProjectilePrefab => _projectilePrefab;
		public GameObject WeaponPrefab => _weaponPrefab;
		
		[SerializeField]
		private GameObject _projectilePrefab;
		[SerializeField]
		private GameObject _weaponPrefab;
	}
}