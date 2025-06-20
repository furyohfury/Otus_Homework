using UnityEngine;

namespace Game
{
	public static class Layers
	{
		public static int Character = LayerMask.NameToLayer("Character");
		public static int Enemy = LayerMask.NameToLayer("Enemy");
		public static int CharacterProjectile = LayerMask.NameToLayer("CharacterProjectile");
		public static int EnemyProjectile = LayerMask.NameToLayer("EnemyProjectile");
		public static int Ground = LayerMask.NameToLayer("Ground");
	}
}