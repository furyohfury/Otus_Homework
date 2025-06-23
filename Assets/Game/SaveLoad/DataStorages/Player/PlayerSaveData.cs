using UnityEngine;

namespace SaveLoad
{
	public struct PlayerSaveData
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public int Health;
		public float MoveSpeed;
		public float JumpForce;
		public string WeaponId;

		public PlayerSaveData(
			Vector3 position, 
			Quaternion rotation, 
			int health, 
			float moveSpeed, 
			float jumpForce, 
			string weaponId
			)
		{
			Position = position;
			Rotation = rotation;
			Health = health;
			MoveSpeed = moveSpeed;
			JumpForce = jumpForce;
			WeaponId = weaponId;
		}
	}
}