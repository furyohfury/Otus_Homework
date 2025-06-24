using UnityEngine;
using Zenject;

namespace SaveLoad
{
	[CreateAssetMenu(fileName = "SaveLoadSystemsInstaller", menuName = "Create installer/SaveLoad/SaveLoadSystemsInstaller")]
	public sealed class SaveLoadSystemsInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<GameRepository>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<SaveLoadManager>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<LaunchSaveLoadersController>()
			         .AsSingle();
		}
	}
}