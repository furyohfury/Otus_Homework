using System;
using Atomic.Entities;
using UnityEngine;

namespace SaveLoad
{
	public sealed class CharacterSaveLoader : SaveLoader<PlayerSaveData, IEntityWorld>
	{
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

			return new PlayerSaveData(playerTransform.position,
				playerTransform.rotation,
				playerEntity.GetHealth().Value,
				playerEntity.GetMoveSpeed().Value,
				playerRB.velocity,
				playerEntity.GetJumpForce().Value);
		}

		protected override void SetupData(IEntityWorld world, PlayerSaveData data)
		{
			var playerEntity = world.GetEntityWithTag(TagAPI.Character);

			SetMovementData(data, playerEntity);
			ResetAbilityAndWeapons(playerEntity);
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
			playerRB.velocity = data.Velocity;
			playerEntity.GetJumpForce().Value = data.JumpForce;
		}

		private void ResetAbilityAndWeapons(IEntity playerEntity)
		{
			if (playerEntity.TryGetAbilityInventory(out var inventory) == false)
			{
				throw new NullReferenceException("No ability inventory found on player");
			}

			// TODO if have time, make ClearAbilityInventoryEvent and fix behaviour
			// but this should work for now
			for (int i = 0, count = inventory.Count; i < count; i++)
			{
				if (playerEntity.TryGetRemoveActiveAbilityEvent(out var removeEvent))
				{
					removeEvent.Invoke();
				}
			}

			// TODO check if needed
			// if (playerEntity.TryGetUnequipWeaponRequest(out var request))
			// {
			// 	request.Invoke();
			// }
		}
	}
}