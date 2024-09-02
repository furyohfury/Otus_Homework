using Lessons.Lesson19_EventBus;
using Zenject;

namespace Game.Installers
{
	public class ZenjectInstaller : MonoInstaller	
	{
		public override void InstallBindings()
		{
			Container.Bind<PlayerTurnPipeline>().AsCached();
			Container.BindInterfacesAndSelfTo<PlayerTurnPipelineInstaller>().AsCached();
			Container.Bind<PlayerTurnPipelineRunner>().AsCached();
		}
	}
}