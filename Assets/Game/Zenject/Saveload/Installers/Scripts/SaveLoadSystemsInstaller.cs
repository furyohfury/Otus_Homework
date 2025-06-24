using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadSystemsInstaller", menuName = "Create installer/SaveLoad/SaveLoadSystemsInstaller")]
	public sealed class SaveLoadSystemsInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
#if UNITY_EDITOR
			Container.BindInterfacesAndSelfTo<GameRepository>()
			         .AsSingle()
			         .NonLazy();
#else
			Container.BindInterfacesAndSelfTo<CryptingGameRepository>()
			         .AsSingle()
			         .NonLazy();
#endif

			Container.BindInterfacesAndSelfTo<SaveLoadManager>()
			         .AsSingle()
			         .NonLazy();

			Container.BindInterfacesAndSelfTo<LaunchSaveLoadersController>()
			         .AsSingle()
			         .NonLazy();
		}
	}
}