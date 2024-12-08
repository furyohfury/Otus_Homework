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
			Container.BindInterfacesAndSelfTo<MovementController>().AsSingle().WithArguments(_character);
			Container.Bind<Camera>().FromComponentInHierarchy().AsCached();
			Container.Bind<SceneEntityWorld>().FromComponentInHierarchy().AsCached();
			Container.BindInterfacesAndSelfTo<PauseController>().AsCached().WithArguments(_pauseMenuView);
		}
	}
}