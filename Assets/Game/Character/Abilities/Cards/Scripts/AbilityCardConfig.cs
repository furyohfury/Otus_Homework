using Atomic.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
	[CreateAssetMenu(fileName = "AbilityCardConfig", menuName = "Create config/Ability card config")]
	public sealed class AbilityCardConfig : ScriptableObject
	{
		public Sprite Sprite;
		public IEntityAspect[] Aspects => _aspects;
		// [SerializeReference]
		// public IEntityAspect WeaponAspect;
		// [SerializeReference]
		// public IEntityAspect AbilityAspect;
		[SerializeReference]
		private IEntityAspect[] _aspects;
	}
}