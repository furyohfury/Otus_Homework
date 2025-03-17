using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class InputSystemUIInstaller : MonoInstaller
	{
		[SerializeField]
		private RebindMenuView _rebindMenuView;
		[SerializeField]
		private InputRebindMenuConfig _rebindMenuConfig;
		
		public override void InstallBindings()
		{
			Container.Bind<RebindMenuView>()
			         .FromInstance(_rebindMenuView)
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<RebindMenuPresenter>()
			         .AsSingle()
			         .WithArguments(_rebindMenuConfig);
		}
	}
}