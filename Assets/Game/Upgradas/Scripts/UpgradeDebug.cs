using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class UpgradeDebug : MonoBehaviour
{
	[ShowInInspector, Readonly]
	private ConveyorModel _conveyorModel;

	private UpgradeSystem _upgradeSystem;

	private void Awake()
	{
		
	}

	[Button]
	public void LevelUp()
	{
		_upgrade.LevelUp();
	}
}