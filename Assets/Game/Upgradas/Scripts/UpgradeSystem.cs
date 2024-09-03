using System.Collections.Generic;
using Game.GamePlay.Upgrades;
using UnityEngine;
using Zenject;

namespace Upgrades
{
	public sealed class UpgradeSystem : IInitializable
	{
		public Dictionary<string, Upgrade> Upgrades { get; } = new();
		private readonly IMoneyStorage _moneyStorage;

		[Inject]
		public UpgradeSystem(IMoneyStorage moneyStorage, UpgradeConfig[] configs, DiContainer diContainer)
		{
			_moneyStorage = moneyStorage;
			foreach (var config in configs)
			{
				var upgrade = config.InstantiateUpgrade();
				diContainer.Inject(upgrade);
				Upgrades.Add(config.Id, upgrade);
			}
		}

		public void Initialize()
		{
			foreach (var upgrade in Upgrades.Values)
			{
				var savedLevel = upgrade.Id;
				if (PlayerPrefs.HasKey(savedLevel))
				{
					upgrade.SetupLevel(PlayerPrefs.GetInt(savedLevel));
				}
			}
		}

		public bool TryUpgrade(string id)
		{
			if (!Upgrades.TryGetValue(id, out var upgrade))
				return false;

			if (!upgrade.IsMaxLevel && _moneyStorage.CanSpendMoney(upgrade.NextPrice))
			{
				upgrade.LevelUp();
				_moneyStorage.SpendMoney(upgrade.NextPrice);
				return true;
			}

			return false;
		}

		public bool TryUpgrade(UpgradeConfig config)
		{
			return TryUpgrade(config.Id);
		}
	}
}