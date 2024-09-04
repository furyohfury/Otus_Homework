using Lessons.Lesson19_EventBus;
using Zenject;

namespace Game.Installers
{
	public class ZenjectInstaller : MonoInstaller	
	{
		public override void InstallBindings()
		{
			// Services
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.Bind<CurrentHeroService().AsSingle();

			// Pipeline
			Container.Bind<PlayerTurnPipeline>().AsCached();
			Container.BindInterfacesAndSelfTo<PlayerTurnPipelineInstaller>().AsCached();
			Container.Bind<PlayerTurnPipelineRunner>().AsCached();
			
			// Event bus logic
			Container.Bind<EventBus>().AsSingle();
			Container.Bind<AttackHandler>().AsSingle();			
			Container.Bind<DealDamageHandler>().AsSingle();
			Container.Bind<DestroyHandler>().AsSingle();

			// Event bus visual
			Container.Bind<AttackVisualHandler>().AsSingle();
			Container.Bind<DestroyVisualHandler>().AsSingle();
		}
	}
}