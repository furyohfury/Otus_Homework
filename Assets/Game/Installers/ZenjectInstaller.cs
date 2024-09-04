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
			Container.Bind<TurnPipeline>().AsCached();
			Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsCached();
			Container.Bind<TurnPipelineRunner>().AsCached();
			
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