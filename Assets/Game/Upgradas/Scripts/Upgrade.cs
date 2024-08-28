using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Upgrades
{
	[Serializable]
	public abstract class Upgrade
	{
		[ShowInInspector] [ReadOnly]
		public int Level { get; private set; } = 1;

		[ShowInInspector] [ReadOnly]
		public int MaxLevel => _config._maxLevel;

		[ShowInInspector] [ReadOnly]
		public bool IsMaxLevel => Level >= _config._maxLevel;

		[ShowInInspector] [ReadOnly]
		public int NextPrice => _config._priceTable.GetPrice(Level + 1);

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
			PlayerPrefs.SetInt(GetType().ToString(), Level);
		}

		public abstract void OnLevelUp(int i);

		public void SetupLevel(int savedLevel)
		{
			Level = savedLevel;
		}
	}
}