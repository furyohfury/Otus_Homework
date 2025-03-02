using System.Collections.Generic;
using System.Linq;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "AbilityCardConfigs", menuName = "Create saveload config/Ability card configs")]
	public sealed class AbilityCardConfigs : SerializedScriptableObject
	{
		public Dictionary<string, AbilityCardConfig> Configs => _configs.ToDictionary(config => config.Id, config => config);

		[SerializeField]
		private AbilityCardConfig[] _configs;
	}
}