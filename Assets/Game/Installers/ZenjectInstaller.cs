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
		[SerializeField]
		private ParticleSystem _damagedParticleSystem;
		[SerializeField]
		private AudioSource _audioSource;

		public override void InstallBindings()
		{
			Application.targetFrameRate = 60;
			// Scene
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesAndSelfTo<CurrentHeroService>().AsSingle();
			Container.Bind<AudioSource>().FromInstance(_audioSource).AsSingle(); // TODO mb some service or smth

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
			Container.BindInterfacesAndSelfTo<RemoveDivineShieldHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();

			// Event bus visual
			Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle().WithArguments(_damagedParticleSystem);
			Container.BindInterfacesAndSelfTo<RemoveDivineShieldVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
		}
	}
}