using UnityEngine;
using Zenject;

namespace SaveLoad
{
	public sealed class SaveLoadSystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private SaveLoadManager _saveLoadManager;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<GameRepository>()
			         .AsSingle()
			         .NonLazy();
			
			Container.Bind<SaveLoadManager>()
			         .FromInstance(_saveLoadManager)
			         .AsSingle()
			         .NonLazy();
		}
	}
}