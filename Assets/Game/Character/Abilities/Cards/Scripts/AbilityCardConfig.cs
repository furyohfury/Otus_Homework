using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "AbilityCardConfig", menuName = "Create config/Ability card config")]
	public sealed class AbilityCardConfig : ScriptableObject
	{
		public AbilityAspect Aspect;
	}
}