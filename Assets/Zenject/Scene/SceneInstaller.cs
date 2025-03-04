using Atomic.Entities;
using GameDebug;
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
			InstallGameLifeCycle();
			InstallEntitiesSystem();

			Container.Bind<Transform>()
			         .WithId("WorldTransform")
			         .FromInstance(_worldTransform)
			         .AsSingle();

			Container.Bind<Camera>()
			         .FromComponentInHierarchy().AsCached();

			Container.BindInterfacesAndSelfTo<CharacterDeathObserver>()
			         .AsSingle()
			         .WithArguments(_character);

			Container.BindInterfacesAndSelfTo<BackgroundController>()
			         .AsSingle()
			         .WithArguments(_backGroundTransform);

#if UNITY_EDITOR
			Container.Bind<DebugHelper>().AsSingle();
#endif
		}

		private void InstallGameLifeCycle()
		{
			Container.Bind<GameStateManager>()
			         .AsSingle();

			Container.Bind<GameLauncher>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<GamePauseController>()
			         .AsSingle();
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