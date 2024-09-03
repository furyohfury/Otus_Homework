using UnityEngine;

namespace Upgrades
{
	public abstract class UpgradeConfig : ScriptableObject
	{
		public string Id;
		public int _maxLevel; // TODO naming pascalcase
		public UpgradePriceTable _priceTable;

		protected virtual void OnValidate()
		{
			_priceTable.OnValidate(_maxLevel);
		}

		public abstract Upgrade InstantiateUpgrade();
	}
}