using Game.GamePlay.Upgrades;
using UnityEngine;
using Upgrades;
using Zenject;


public class SceneInstaller : MonoInstaller
{
	[SerializeField]
	private UpgradeConfig[] _upgradeConfigs;

	public override void InstallBindings()
	{
		Container.Bind<ConveyorModel>().FromComponentInHierarchy().AsSingle();
		Container.Bind<IMoneyStorage>().To<MoneyStorage>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<UpgradeSystem>().AsSingle();
		Container.Bind<UpgradeConfig[]>().FromInstance(_upgradeConfigs).AsCached();		
	}
}