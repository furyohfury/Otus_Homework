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
		private SceneEntityWorld _entityWorld;
		[SerializeField]
		private GameObject _pauseMenuView;
		
		public override void InstallBindings()
		{
#if UNITY_EDITOR
			Container.Bind<DebugHelper>().AsSingle(); // TODO delete
#endif
			Container.BindInterfacesAndSelfTo<MovementController>()
			         .AsSingle()
			         .WithArguments(_character);
			
			Container.Bind<Camera>()
			         .FromComponentInHierarchy().AsCached();
			
			Container.Bind<IEntityWorld>()
			         .To<SceneEntityWorld>()
			         .FromComponentInHierarchy()
			         .AsCached();
			
			// Container.BindInterfacesAndSelfTo<PauseController>()
			//          .AsCached()
			//          .WithArguments(_pauseMenuView);
			
			Container.BindInterfacesAndSelfTo<SceneEntityCreator>()
			         .AsSingle();

			Container.Bind<GameStateManager>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<EntityWorldStateController>()
			         .AsSingle();
		}
	}
}