using a;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public class SceneInstaller : MonoInstaller
	{
		[SerializeField]
		private SceneEntity _character;
		[SerializeField]
		private Transform _worldTransform;
		[SerializeField] 
		private Transform _backGroundTransform;

		public override void InstallBindings()
		{
#if UNITY_EDITOR
			Container.Bind<DebugHelper>().AsSingle();
#endif
			Container.Bind<Transform>()
			         .WithId("WorldTransform")
			         .FromInstance(_worldTransform)
			         .AsSingle();
			
			InstalllPlayerInputControllers();

			Container.BindInterfacesAndSelfTo<GamePauseController>()
			         .AsSingle();
			
			Container.Bind<Camera>()
			         .FromComponentInHierarchy().AsCached();

			Container.BindInterfacesAndSelfTo<CharacterDeathObserver>()
			         .AsSingle()
			         .WithArguments(_character);

			Container.BindInterfacesAndSelfTo<BackgroundController>()
			         .AsSingle()
			         .WithArguments(_backGroundTransform);
			
			InstallGameLifeCycle();
			InstallEntitiesSystem();
		}

		private void InstalllPlayerInputControllers()
		{
			Container.BindInterfacesAndSelfTo<PlayerTargetController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerJumpController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerXAxisMovementController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerAttackController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.BindInterfacesAndSelfTo<PlayerAbilityController>()
			         .AsSingle()
			         .WithArguments(_character);
		}

		private void InstallGameLifeCycle()
		{
			Container.Bind<GameStateManager>()
			         .AsSingle();

			Container.Bind<GameLauncher>()
			         .AsCached();  // TODO hz naschet etogo
		}

		private void InstallEntitiesSystem()
		{
			Container.Bind<IEntityWorld>()
			         .FromComponentInHierarchy()
			         .AsCached();
			
			Container.BindInterfacesAndSelfTo<EntityWorldStateController>()
			         .AsSingle();
		}
	}
}