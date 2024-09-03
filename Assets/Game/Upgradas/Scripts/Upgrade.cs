using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Upgrades
{
	[Serializable]
	public abstract class Upgrade
	{
		[ShowInInspector] [ReadOnly]
		public int Id => _config.Id;

		[ShowInInspector] [ReadOnly]
		public int Level { get; private set; } = 1;

		[ShowInInspector] [ReadOnly]
		public int MaxLevel => _config._maxLevel;

		[ShowInInspector] [ReadOnly]
		public bool IsMaxLevel => Level >= _config._maxLevel;

		[ShowInInspector] [ReadOnly]
		public int NextPrice => _config._priceTable.GetPrice(Level + 1); // TODO check if works properly w/ 1st level

		private readonly UpgradeConfig _config;

		protected Upgrade(UpgradeConfig config)
		{
			_config = config;
		}

		[Button]
		public void LevelUp()
		{
			Level++;
			OnLevelUp(Level);
			PlayerPrefs.SetInt(Id, Level);
		}

		public abstract void OnLevelUp(int level);

		public void SetupLevel(int savedLevel)
		{
			Level = savedLevel;
		}
	}
}