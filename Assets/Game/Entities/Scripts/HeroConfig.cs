using UnityEngine;

namespace Entities
{
	[CreateAssetMenu(fileName = "HeroConfig", menuName = "Create config/Hero config", order = 0)]
	public class HeroConfig : ScriptableObject
	{
		public int CurrentHealth;
		public int MaxHealth;
		public int Damage;
		public AttackEffects AttackEffects;
		// public Sprite Icon;
		// public Effect[] Effects;
	}
}