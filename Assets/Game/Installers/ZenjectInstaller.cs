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
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.Bind<EventBus>().AsSingle();
			Container.Bind<CurrentHeroService().AsSingle();

			Container.Bind<AttackHandler>().AsSingle();
			Container.Bind<AttackVisualHandler>().AsSingle();
		}
	}
}