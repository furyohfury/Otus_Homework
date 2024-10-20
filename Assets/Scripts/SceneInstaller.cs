using Zenject;

namespace RealTime
{
	public sealed class SceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<MoneyStorage>().FromComponentInHierarchy().AsSingle();
			Container.Bind<OilStorage>().FromComponentInHierarchy().AsSingle();
			Container.Bind<ChestSpawner>().AsSingle();
			Container.Bind<ChestManager>().FromComponentInHierarchy().AsSingle();
		}
	}
}