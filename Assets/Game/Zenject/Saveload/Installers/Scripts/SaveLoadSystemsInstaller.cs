using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadSystemsInstaller", menuName = "Create installer/SaveLoad/SaveLoadSystemsInstaller")]
	public sealed class SaveLoadSystemsInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Debug.Log("Installing saveloadsystems");
			Container.BindInterfacesAndSelfTo<GameRepository>()
			         .AsSingle()
			         .NonLazy();

			Container.BindInterfacesAndSelfTo<SaveLoadManager>()
			         .AsSingle()
			         .NonLazy();

			Container.BindInterfacesAndSelfTo<LaunchSaveLoadersController>()
			         .AsSingle()
			         .NonLazy();
			Debug.Log("Successfully installed saveloadsystems");
		}
	}
}