using UnityEngine;

namespace Upgrades
{
	[CreateAssetMenu(menuName = "Create update config/Unload Storage Capacity",
		fileName = "UnloadStorageCapacityUpdateConfig")]
	public sealed class UnloadStorageCapacityUpgradeConfig : UpgradeConfig
	{
		public override Upgrade InstantiateUpgrade()
		{
			return new UnloadStorageCapacityUpgrade(this);
		}
	}
}