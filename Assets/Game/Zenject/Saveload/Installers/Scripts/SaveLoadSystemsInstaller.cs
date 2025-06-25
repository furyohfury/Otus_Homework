using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadSystemsInstaller", menuName = "Create installer/SaveLoad/SaveLoadSystemsInstaller")]
	public sealed class SaveLoadSystemsInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
#if UNITY_WEBGL
			Container.BindInterfacesAndSelfTo<NonFileGameRepository>()
			         .AsSingle();
#else
			Container.BindInterfacesAndSelfTo<GameRepository>()
			         .AsSingle();
#endif
			Container.BindInterfacesAndSelfTo<SaveLoadManager>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<LaunchSaveLoadersController>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<PlayfabLoggedObserver>()
			         .AsSingle();
		}
	}
}