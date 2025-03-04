using System.Collections.Generic;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuInstaller : MonoInstaller // TODO dictionaries to configs
	{
		[SerializeField]
		private LevelMiniatureView _levelMiniatureViewPrefab;
		[SerializeField] [Space]
		private Dictionary<Cups, Sprite> _cupsSprite;
		[SerializeField] [Space]
		private Dictionary<string, Sprite> _levelsIcons;
		[SerializeField]
		private Transform _container;
		[SerializeField]
		private SelectLeveMenuView _selectLeveMenuView;
		[SerializeField]
		private MainMenuView _mainMenuView;
		
		
		public override void InstallBindings()
		{
			InstallFactories();
			InstallSelectLevelMenu();
			
			Container.BindInterfacesAndSelfTo<MainMenuPresenter>()
			         .AsCached()
			         .WithArguments(_selectLeveMenuView, _mainMenuView);

		}

		private void InstallFactories()
		{
			Container.BindInterfacesAndSelfTo<LevelMiniaturePresenterFactory>()
			         .AsCached()
			         .WithArguments(_cupsSprite);

			Container.BindInterfacesAndSelfTo<LevelMiniatureViewFactory>()
			         .AsCached()
			         .WithArguments(_levelMiniatureViewPrefab);
		}

		private void InstallSelectLevelMenu()
		{
			Container.BindInterfacesAndSelfTo<SelectLevelMenuPresenter>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<SelectLeveMenuView>()
			         .FromInstance(_selectLeveMenuView)
			         .AsSingle();
		}
	}
}