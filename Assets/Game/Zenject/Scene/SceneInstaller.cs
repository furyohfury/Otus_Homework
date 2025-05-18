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
		private Transform _enemiesContainer;
		[SerializeField]
		private Transform _abilityCardsContainer;
		[SerializeField] 
		private Transform _levelEntitiesContainer;
		
		[SerializeField]
		private Transform _backGroundTransform;

		public override void InstallBindings()
		{
			InstallGameLifeCycle();
			InstallEntitiesSystem();
			InstallServices();

			Container.Bind<Transform>()
			         .WithId("WorldTransform")
			         .FromInstance(_worldTransform)
			         .AsSingle();


			Container.Bind<Camera>()
			         .FromComponentInHierarchy().AsCached();

			Container.BindInterfacesAndSelfTo<BackgroundController>()
			         .AsSingle()
			         .WithArguments(_backGroundTransform);
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