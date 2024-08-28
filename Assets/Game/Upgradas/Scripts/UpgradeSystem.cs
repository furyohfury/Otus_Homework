namespace Upgrades
{
    public sealed class UpgradeSystem : IGameStartListener
    {
        private Dictionary<string, Upgrade> _upgrades = new();

        public UpgradeSystem(UpgradeConfig[] configs)
        {
            _upgrades = new Upgrade[configs.Length];
            for (var i = 0; i < _upgrades.Length; i++)
            {
                var upgrade = configs[i].InstantiateUpgrade();
                _upgrades.Add(upgrade.Id, upgrade);
            }
        }

        public void StartGame()
        {

        }   
    }
}