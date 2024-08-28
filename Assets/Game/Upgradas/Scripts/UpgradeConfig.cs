using UnityEngine;

namespace Upgrades
{
	public abstract class UpgradeConfig : ScriptableObject
	{
		public int _maxLevel;
		public UpgradePriceTable _priceTable;

		protected virtual void OnValidate()
		{
			_priceTable.OnValidate(_maxLevel);
		}

		public abstract Upgrade InstantiateUpgrade();
	}
}