using Entities;
using EventBus;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public class ZenjectInstaller : MonoInstaller
	{
		[SerializeField]
		private HeroEntity[] _playerOneHeroes;
		[SerializeField]
		private HeroEntity[] _playerTwoHeroes;

		public override void InstallBindings()
		{
			Application.targetFrameRate = 60;
			// Scene
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesAndSelfTo<CurrentHeroService>().AsSingle();

			// Pipeline
			Container.Bind<VisualPipeline>().AsCached();

			var playerTurnPipeline = new TurnPipeline();
			Container.Bind<TurnPipeline>().FromInstance(playerTurnPipeline).AsCached();
			Container.BindInterfacesAndSelfTo<PlayerTurnPipelineInstaller>().AsCached()
			         .WithArguments(playerTurnPipeline);
			var aiTurnPipeline = new TurnPipeline();
			Container.Bind<TurnPipeline>().FromInstance(aiTurnPipeline).AsCached();
			Container.BindInterfacesAndSelfTo<AITurnPipelineInstaller>().AsCached().WithArguments(aiTurnPipeline);

			Container.BindInterfacesAndSelfTo<GamePipelineRunner>().AsCached()
			         .WithArguments(_playerOneHeroes, _playerTwoHeroes);

			// Event bus logic
			Container.Bind<EventBus.EventBus>().AsSingle();
			Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();

			// Event bus visual
			Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
		}
	}
}