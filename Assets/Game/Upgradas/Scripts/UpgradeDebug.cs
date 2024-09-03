using System.Collections.Generic;
using Game.GamePlay.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;
using Upgrades;
using Zenject;

public class UpgradeDebug : MonoBehaviour
{
	[ShowInInspector] [ReadOnly]
	public Dictionary<string, Upgrade> Upgrades;

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
	public void LevelUpUpgrade(UpgradeConfig config)
	{
		if (!_upgradeSystem.TryUpgrade(config))
		{
			Debug.Log($"Cant upgrade {config.Id}");
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