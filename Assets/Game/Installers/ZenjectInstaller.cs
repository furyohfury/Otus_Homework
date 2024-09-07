using Entities;
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
			// Scene
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesAndSelfTo<CurrentHeroService>().AsSingle();
			Container.Bind<HeroEntity>().FromComponentsInHierarchy().AsCached();

			// Pipeline
			Container.Bind<VisualPipeline>().AsCached();

			var playerTurnPipeline = new TurnPipeline();	
			Container.Bind<TurnPipeline>().FromInstance(playerTurnPipeline).AsCached();		
			Container.BindInterfacesAndSelfTo<PlayerTurnPipelineInstaller>().AsCached().WithArguments(playerTurnPipeline);
			var aiTurnPipeline = new TurnPipeline();	
			Container.Bind<TurnPipeline>().FromInstance(aiTurnPipeline).AsCached();		
			Container.BindInterfacesAndSelfTo<AITurnPipelineInstaller>().AsCached().WithArguments(aiTurnPipeline);

			Container.BindInterfacesAndSelfTo<GamePipelineRunner>().AsCached();
			
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