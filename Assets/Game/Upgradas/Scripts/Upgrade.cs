using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Upgrades
{
	[Serializable]
	public abstract class Upgrade
	{
		[ShowInInspector] [ReadOnly]
		public string Id => _config.Id;

		[ShowInInspector] [ReadOnly]
		public int Level { get; private set; } = 1;

		[ShowInInspector] [ReadOnly]
		public int MaxLevel => _config.MaxLevel;

		[ShowInInspector] [ReadOnly]
		public bool IsMaxLevel => Level >= _config.MaxLevel;

		[ShowInInspector] [ReadOnly]
		public int NextPrice => _config.PriceTable.GetPrice(Level + 1);

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