using UnityEngine;

namespace SaveLoad
{
	public struct PlayerSaveData
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public int Health;
		public float MoveSpeed;
		public Vector3 Velocity;
		public float JumpForce;
		public string WeaponId;

		public PlayerSaveData(Vector3 position, Quaternion rotation, int health, float moveSpeed, Vector3 velocity, float jumpForce, string weaponId)
		{
			Position = position;
			Rotation = rotation;
			Health = health;
			MoveSpeed = moveSpeed;
			Velocity = velocity;
			JumpForce = jumpForce;
			WeaponId = weaponId;
		}
	}
}