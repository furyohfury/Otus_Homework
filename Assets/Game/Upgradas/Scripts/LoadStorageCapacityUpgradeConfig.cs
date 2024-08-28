using UnityEngine;

namespace Upgrades
{
[CreateAssetMenu(menuName = "Create update config/Load Storage Capacity", fileName = "LoadStorageCapacityUpdateConfig")]
public sealed class LoadStorageCapacityUpgradeConfig : UpgradeConfig
{
	public override Upgrade InstantiateUpgrade()
	{
		return new LoadStorageCapacityUpgrade(this);
	}
}
}