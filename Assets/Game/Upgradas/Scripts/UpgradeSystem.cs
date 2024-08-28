namespace Upgrades
{
    public sealed class UpgradeSystem : IGameStartListener
    {
        private readonly IMoneyStorage _moneyStorage;
	private readonly Dictionary<Type, Upgrade> _upgrades = new();

	public UpgradeSystem(IMoneyStorage moneyStorage, UpgradeConfig[] configs)
	{
		_moneyStorage = moneyStorage;
		_configs = configs;
		foreach (var config in _configs)
		{
			var upgrade = config.InstantiateUpgrade();
			_upgrades.Add(upgrade.GetType(), upgrade);
		}
	}

	public bool TryUpgrade<T>() where T : Upgrade
	{
		if (!_upgrades.TryGetValue(typeof(T), out var upgrade))
			return false;
        
		if (!upgrade.IsMaxLevel && _moneyStorage.CanSpendMoney(upgrade.NextPrice))
		{
			upgrade.LevelUp();
			_moneyStorage.SpendMoney(upgrade.NextPrice);
			return true;
		}

		return false;
	}

        public void StartGame()
        {
            foreach (var upgrade in _upgrades.Values)
            {
                var savedLevel = PlayerPrefs.GetInt(upgrade.GetType());
                upgrade.SetupLevel(savedLevel);
            }
        }   
    }
}