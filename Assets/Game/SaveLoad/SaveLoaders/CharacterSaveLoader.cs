using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class CharacterSaveLoader : SaveLoader<PlayerSaveData, IEntityWorld>
	{
		private readonly Dictionary<string, SceneEntity> _weaponPrefabs;

		[Inject]
		public CharacterSaveLoader(Dictionary<string, SceneEntity> weaponPrefabs)
		{
			_weaponPrefabs = weaponPrefabs;
		}

		protected override PlayerSaveData ConvertToData(IEntityWorld world)
		{
			var playerEntity = world.GetEntityWithTag(TagAPI.Character);

			if (playerEntity == null)
			{
				Debug.LogError("No player found on scene");
				return default;
			}

			if (!playerEntity.TryGetVisualTransform(out Transform playerTransform)
			    || !playerEntity.TryGetRigidbody2D(out Rigidbody2D playerRB))
			{
				throw new Exception("No transform/rb in player entity");
			}

			string weaponId = string.Empty;
			if (playerEntity.TryGetWeapon(out ReactiveVariable<SceneEntity> weapon))
			{
				weaponId = weapon.Value.GetId();
			}
			else
			{
				weaponId = string.Empty;
			}

			return new PlayerSaveData(playerTransform.position,
				playerTransform.rotation,
				playerEntity.GetHealth().Value,
				playerEntity.GetMoveSpeed().Value,
				playerRB.linearVelocity,
				playerEntity.GetJumpForce().Value,
				weaponId);
		}

		protected override void SetupData(IEntityWorld world, PlayerSaveData data)
		{
			var playerEntity = world.GetEntityWithTag(TagAPI.Character);

			SetMovementData(data, playerEntity);
			ResetWeapon(playerEntity, data);
			ResetAbility(playerEntity, data);
			ResetVelocity(playerEntity);
		}

		private void SetMovementData(PlayerSaveData data, IEntity playerEntity)
		{
			if (!playerEntity.TryGetVisualTransform(out Transform playerTransform)
			    || !playerEntity.TryGetRigidbody2D(out Rigidbody2D playerRB))
			{
				throw new Exception("No transform/rb in player entity");
			}

			playerTransform.position = data.Position;
			playerTransform.rotation = data.Rotation;
			playerEntity.GetHealth().Value = data.Health;
			playerEntity.GetMoveSpeed().Value = data.MoveSpeed;
			playerRB.linearVelocity = data.Velocity;
			playerEntity.GetJumpForce().Value = data.JumpForce;
		}

		private void ResetWeapon(IEntity playerEntity, PlayerSaveData data)
		{
			if (playerEntity.TryGetWeapon(out var equippedWeapon))
			{
				playerEntity.GetUnequipWeaponRequest().Invoke();
			}
			
			if (string.IsNullOrEmpty(data.WeaponId))
			{
				return;
			}

			var weapon = _weaponPrefabs[data.WeaponId];
			playerEntity.GetEquipWeaponRequest().Invoke(weapon);
		}

		private void ResetAbility(IEntity playerEntity, PlayerSaveData data)
		{
			if (playerEntity.TryGetAbilityInventory(out var inventory) == false)
			{
				throw new NullReferenceException("No ability inventory found on player");
			}

			for (int i = 0, count = inventory.Count; i < count; i++)
			{
				if (playerEntity.TryGetRemoveActiveAbilityEvent(out var removeEvent))
				{
					removeEvent.Invoke();
				}
			}
		}

		private static void ResetVelocity(IEntity playerEntity)
		{
			playerEntity.GetRigidbody2D().linearVelocity = Vector2.zero;
			playerEntity.GetMoveDirection().Value = Vector2.zero;
		}
	}
}