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
			Debug.Log("Cant upgrade ProduceTime");
		}
	}

	[Button]
	public void LevelUpLoadStorageCapacity()
	{
		if (!_upgradeSystem.TryUpgrade<LoadStorageCapacityUpgrade>())
		{
			Debug.Log("Cant upgrade LoadStorageCapacity");
		}
	}

	[Button]
	public void LevelUpUnloadStorageCapacity()
	{
		if (!_upgradeSystem.TryUpgrade<UnloadStorageCapacityUpgrade>())
		{
			Debug.Log("Cant upgrade UnloadStorageCapacity");
		}
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