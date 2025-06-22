using Atomic.Entities;
using SaveLoad;
using Unity.Cinemachine;
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
		private Transform _enemiesContainer;
		[SerializeField]
		private Transform _abilityCardsContainer;
		[SerializeField]
		private Transform _levelEntitiesContainer;

		public override void InstallBindings()
		{
			InstallGameLifeCycle();
			InstallEntitiesSystem();
			InstallServices();
			InstallCameraSystems();
		}

		private void InstallCameraSystems()
		{
			Container.Bind<Camera>()
			         .FromComponentInHierarchy().AsSingle();

			Container.BindInterfacesAndSelfTo<CameraShaker>()
			         .AsSingle();

			Container.Bind<CinemachineImpulseSource>()
			         .FromComponentInHierarchy()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<CameraShakeController>()
			         .AsSingle();
		}

		private void InstallServices()
		{
			Container.Bind<PlayerService>()
			         .AsSingle()
			         .WithArguments(_character);

			Container.BindInterfacesAndSelfTo<EnemyService>()
			         .AsSingle()
			         .WithArguments(_enemiesContainer);

			Container.Bind<AbilityCardsService>()
			         .AsSingle()
			         .WithArguments(_abilityCardsContainer);

			Container.Bind<LevelEntitiesService>()
			         .AsSingle()
			         .WithArguments(_levelEntitiesContainer);

			Container.Bind<ProjectileService>()
			         .AsSingle();

			Container.Bind<WorldEntitiesService>()
			         .AsSingle();
		}

		private void InstallGameLifeCycle()
		{
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