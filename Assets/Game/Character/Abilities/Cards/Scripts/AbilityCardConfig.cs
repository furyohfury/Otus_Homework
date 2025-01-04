using Atomic.Extensions;
using Newtonsoft.Json;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "AbilityCardConfig", menuName = "Create config/Ability card config")]
	public sealed class AbilityCardConfig : ScriptableObject
	{
		[JsonIgnore]
		public Sprite Sprite;
		public IEntityAspect[] Aspects => _aspects;

		[SerializeReference]
		private IEntityAspect[] _aspects;
	}
}