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
		private Transform _worldTransform;
		
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
			
			Container.Bind<GameStateManager>()
			         .AsSingle();
			
			Container.BindInterfacesAndSelfTo<SceneEntityCreator>()
			         .AsSingle()
			         .WithArguments(_worldTransform);
			
			Container.BindInterfacesAndSelfTo<EntityWorldStateController>()
			         .AsSingle();
		}
	}
}