using System;
using System.Collections.Generic;
using Game.GamePlay.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;
using Upgrades;
using Zenject;

public class UpgradeDebug : MonoBehaviour
{
	[ShowInInspector] [ReadOnly]
	public Dictionary<Type, Upgrade> Upgrades;

	[ShowInInspector] [ReadOnly] [HorizontalGroup("Money")] [PropertySpace]
	public int Money => _moneyStorage.Money;

	private ConveyorModel _conveyorModel;
	private UpgradeSystem _upgradeSystem;
	private IMoneyStorage _moneyStorage;

	[Inject]
	public void Construct(UpgradeSystem upgradeSystem, IMoneyStorage moneyStorage)
	{
		_upgradeSystem = upgradeSystem;
		_moneyStorage = moneyStorage;
	}

	private void Start()
	{
		Upgrades = _upgradeSystem.Upgrades;
	}

	[Button]
	public void LevelUpProduceTime()
	{
		if (!_upgradeSystem.TryUpgrade<ProduceTimeUpgrade>())
		{
			Debug.Log("Cant upgrade produce time");
		}
	}

	[Button]
	public void LevelUpLoadStorageCapacity()
	{
		_upgradeSystem.TryUpgrade<LoadStorageCapacityUpgrade>();
	}

	[Button]
	public void LevelUpUnloadStorageCapacity()
	{
		_upgradeSystem.TryUpgrade<UnloadStorageCapacityUpgrade>();
	}

	[Button] [HorizontalGroup("Money")]
	public void AddMoney(int money)
	{
		_moneyStorage.EarnMoney(money);
	}

	[Button] [PropertySpace]
	public void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
}