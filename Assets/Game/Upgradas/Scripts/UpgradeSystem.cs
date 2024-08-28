using System;
using System.Collections.Generic;
using Game.GamePlay.Upgrades;
using GameLifeCycle;
using UnityEngine;
using Zenject;

namespace Upgrades
{
	public sealed class UpgradeSystem : IGameStartListener
	{
		public Dictionary<Type, Upgrade> Upgrades { get; } = new();
		private readonly IMoneyStorage _moneyStorage;

		public UpgradeSystem(IMoneyStorage moneyStorage, UpgradeConfig[] configs, DiContainer diContainer)
		{
			_moneyStorage = moneyStorage;
			foreach (var config in configs)
			{
				var upgrade = config.InstantiateUpgrade();
				diContainer.Inject(upgrade);
				Upgrades.Add(upgrade.GetType(), upgrade);
			}

			IGameStateListener.Register(this);
		}

		public bool TryUpgrade<T>() where T : Upgrade
		{
			if (!Upgrades.TryGetValue(typeof(T), out var upgrade))
				return false;

			if (!upgrade.IsMaxLevel && _moneyStorage.CanSpendMoney(upgrade.NextPrice))
			{
				upgrade.LevelUp();
				_moneyStorage.SpendMoney(upgrade.NextPrice);
				return true;
			}

			return false;
		}

		public void StartGame()
		{
			foreach (var upgrade in Upgrades.Values)
			{
				var savedLevel = PlayerPrefs.GetInt(upgrade.GetType().ToString());
				upgrade.SetupLevel(savedLevel);
			}
		}
	}
}