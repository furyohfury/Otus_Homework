using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class CameraShakeController : IInitializable, IDisposable
	{
		private readonly PlayerService _playerService;
		private readonly CameraShaker _cameraShaker;

		public CameraShakeController(PlayerService playerService, CameraShaker cameraShaker)
		{
			_playerService = playerService;
			_cameraShaker = cameraShaker;
		}

		public void Initialize()
		{
			var player = _playerService.Player;
			player.OnValueAdded += OnWeaponAdded;
			player.OnValueDeleted += OnWeaponRemoved;
			if (player.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				weapon.Value.GetAttackEvent().Subscribe(OnPlayerAttack);
			}
		}

		private void OnWeaponAdded(IEntity arg1, int arg2, object arg3)
		{
			if (arg2 != CombatAPI.Weapon)
			{
				return;
			}

			SceneEntity weapon = (arg3 as ReactiveVariable<SceneEntity>).Value;
			weapon.GetAttackEvent().Subscribe(OnPlayerAttack);
		}

		private void OnWeaponRemoved(IEntity arg1, int arg2, object arg3)
		{
			if (arg2 != CombatAPI.Weapon)
			{
				return;
			}

			SceneEntity weapon = (arg3 as ReactiveVariable<SceneEntity>).Value;
			weapon.GetAttackEvent().Unsubscribe(OnPlayerAttack);
		}

		private void OnPlayerAttack()
		{
			Debug.Log("On player attack");
			if (_playerService.Player.TryGetWeapon(out var weapon) == false)
			{
				Debug.Log("Player has no weapon");
			}

			if (weapon.Value.GetCanAttack().Invoke() == false)
			{
				Debug.Log("Players weapon cant attack");
			}

			ShakeCamera();
		}

		private void ShakeCamera()
		{
			_cameraShaker.ShakeCamera(Vector2.up);
		}

		public void Dispose()
		{
			_playerService.Player.OnValueAdded -= OnWeaponAdded;
			_playerService.Player.OnValueDeleted -= OnWeaponRemoved;
		}
	}
}