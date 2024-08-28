using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class UpgradeDebug : MonoBehaviour
{
	[SerializeField]
	private ConveyorModel _conveyorModel;
	[SerializeField]
	private UpgradeConfig _upgradeConfig;

	[ShowInInspector]
	private Upgrade _upgrade;

	private void Awake()
	{
		_upgrade = _upgradeConfig.InstantiateUpgrade();
		var savedLevel = 3;
		_upgrade.SetupLevel(savedLevel);
	}

	[Button]
	public void LevelUp()
	{
		_upgrade.LevelUp();
	}
}