using Zenject;

namespace RealTime
{
	public sealed class SceneInstaller : MonoInstaller
	{
		[SerializedField]
		private Chest _prefab;

		public override void InstallBindings()
		{
			Container.Bind<MoneyStorage>().FromComponentInHierarchy().AsSingle();
			Container.Bind<OilStorage>().FromComponentInHierarchy().AsSingle();
			Container.Bind<ChestSpawner>().AsSingle().WithArguments(_prefab);
			Container.Bind<ChestManager>().FromComponentInHierarchy().AsSingle();
			Container.Bind<FileChestSaveLoader>().To<IChestSaveLoader>().AsSingle();
		}
	}
}