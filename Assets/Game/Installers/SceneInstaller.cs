using UnityEngine;
using Zenject;


public class SceneInstaller : MonoInstaller
{
	[SerialzieField]
	private UpgradeConfig[] _upgradeConfigs;

	public override void InstallBindings()
	{
		Container.Bind<ConveyorModel>().FromComponentInHierarchy().AsSingle();
		Container.Bind<IMoneyStorage>().FromComponentInHierarchy().AsSingle();
		Container.Bind<UpgradeSystem>().AsSingle();
		Container.Bind<UpgradeConfig[]>FromInstance(_upgradeConfigs).AsCached();		
	}
}