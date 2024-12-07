using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "AbilityCardConfig", menuName = "Create config/Ability card config")]
	public sealed class AbilityCardConfig : ScriptableObject
	{
		public Sprite Sprite;
		public IEntityAspect[] Aspects => _aspects;

		[SerializeReference]
		private IEntityAspect[] _aspects;
	}
}