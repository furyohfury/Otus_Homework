using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class UpgradeDebug : MonoBehaviour
{
	[ShowInInspector, Readonly]
	private ConveyorModel _conveyorModel;

	private UpgradeSystem _upgradeSystem;

	public void Construct(UpgradeSystem upgradeSystem)
	{
		_upgradeSystem = upgradeSystem
	}

	[Button]
	public void LevelUpProduceTime()
	{
		_upgradeSystem.TryUpgrade<ProduceTimeUpgrade>();		
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
}