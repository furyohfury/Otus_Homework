using Lessons.Lesson19_EventBus;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public class ZenjectInstaller : MonoInstaller	
	{
		public override void InstallBindings()
		{
			Application.targetFrameRate = 60;
			// Services
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesAndSelfTo<CurrentHeroService>().AsSingle();

			// Pipeline
			Container.Bind<TurnPipeline>().AsCached();
			Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsCached();
			Container.BindInterfacesAndSelfTo<TurnPipelineRunner>().AsCached();
			
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