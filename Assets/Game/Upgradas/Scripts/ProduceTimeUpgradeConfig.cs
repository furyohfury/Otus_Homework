using UnityEngine;

namespace Upgrades
{
[CreateAssetMenu(menuName = "Create update config/Produce time", fileName = "ProduceTimeUpdateConfig")]
public sealed class ProduceTimeUpgradeConfig : UpgradeConfig
{
	public override Upgrade InstantiateUpgrade()
	{
		return new ProduceTimeUpgrade(this);
	}
}
}