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
			Container.Bind<VisualPipeline>().AsCached();
			Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsCached();
			Container.BindInterfacesAndSelfTo<TurnPipelineRunner>().AsCached();
			
			// Event bus logic
			Container.Bind<EventBus>().AsSingle();
			Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();			
			Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();

			// Event bus visual
			Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
		}
	}
}