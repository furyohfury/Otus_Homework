using UnityEngine;

namespace Upgrades
{
	public abstract class UpgradeConfig : ScriptableObject
	{
		public string Id;
		public int MaxLevel;
		public UpgradePriceTable PriceTable;

		protected virtual void OnValidate()
		{
			PriceTable.OnValidate(MaxLevel);
		}

		public abstract Upgrade InstantiateUpgrade();
	}
}