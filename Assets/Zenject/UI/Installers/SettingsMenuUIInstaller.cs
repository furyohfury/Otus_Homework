using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class SettingsMenuUIInstaller : MonoInstaller
	{
		[SerializeField]
		private SettingsMenuView _settingsMenuView;
		
		public override void InstallBindings()
		{
			Container.Bind<SettingsMenuView>()
			         .FromInstance(_settingsMenuView)
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<SettingsMenuPresenter>()
			         .AsSingle();
		}
	}
}