using Atomic.Entities;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public sealed class AbilityEquipDebugHelper : MonoBehaviour
	{
		[SerializeField]
		private AbilityCardConfig _config;
		[SerializeField]
		private SceneEntity _player;

		[Button]
		private void EquipWeapon()
		{
			_player.GetRemoveActiveAbilityEvent().Invoke();
			_player.GetAbilityCardPickupEvent().Invoke(_config);
		}
	}
}