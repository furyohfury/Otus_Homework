﻿using System;
using Sirenix.OdinInspector;

[Serializable]
public abstract class Upgrade
{
	[ShowInInspector] [ReadOnly]
	public string Id => _config.id;

	[ShowInInspector] [ReadOnly]
	public int Level { get; private set; } = 1;

	[ShowInInspector] [ReadOnly]
	public int MaxLevel => _config.maxLevel;

	[ShowInInspector] [ReadOnly]
	public bool IsMaxLevel => Level >= _config.maxLevel;

	[ShowInInspector] [ReadOnly]
	public int NextPrice => _config.priceTable.GetPrice(Level + 1);

	private readonly UpgradeConfig _config;

	protected Upgrade(UpgradeConfig config)
	{
		_config = config;
	}

	[Button]
	public void LevelUp()
	{
		if (IsMaxLevel)
		{
			throw new Exception("Can't upgrade max level!");
		}

		Level++;
		OnLevelUp(Level);
	}

	public abstract void OnLevelUp(int i);

	public void SetupLevel(int savedLevel)
	{
		Level = savedLevel;
	}
}