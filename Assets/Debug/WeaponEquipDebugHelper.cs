using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class WeaponEquipDebugHelper : MonoBehaviour
	{
		[SerializeField]
		private SceneEntity _prefab;
		[SerializeField]
		private SceneEntity _player;

		[Button]
		private void EquipWeapon()
		{
			_player.GetUnequipWeaponRequest().Invoke();
			_player.GetEquipWeaponRequest().Invoke(_prefab);
		}
	}
}