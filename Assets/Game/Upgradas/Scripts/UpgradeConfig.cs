﻿using UnityEngine;

namespace Upgrades
{
public abstract class UpgradeConfig : ScriptableObject
{
	public string id;
	public int maxLevel;
	public UpgradePriceTable priceTable;

	protected virtual void OnValidate()
	{
		priceTable.OnValidate(maxLevel);
	}

	public abstract Upgrade InstantiateUpgrade();
}
}