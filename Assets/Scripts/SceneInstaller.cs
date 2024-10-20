using Zenject;

namespace RealTime
{
	public sealed class SceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<MoneyStorage>().FromComponentInHierarchy();
			Container.Bind<OilStorage>().FromComponentInHierarchy();
		}
	}
}