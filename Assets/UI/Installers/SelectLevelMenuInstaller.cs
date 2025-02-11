using System.Collections.Generic;
using Game;
using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuInstaller : MonoInstaller // TODO all dictionaries to configs
	{
		[SerializeField]
		private LevelMiniatureView _levelMiniatureViewPrefab;
		[SerializeField] [Space]
		private Dictionary<string, LevelCupsTimesConfig> _cupsTimesConfigs;
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
			Container.BindInterfacesAndSelfTo<MainMenuPresenter>()
			         .AsCached()
			         .WithArguments(_selectLeveMenuView, _mainMenuView);
			
			Container.BindInterfacesAndSelfTo<LevelMiniaturePresenterFactory>()
			         .AsCached()
			         .WithArguments(_cupsTimesConfigs, _cupsSprite, _levelsIcons);

			Container.BindInterfacesAndSelfTo<SelectLevelMenuPresenter>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<LevelMiniatureViewFactory>()
			         .AsCached()
			         .WithArguments(_levelMiniatureViewPrefab);

			Container.BindInterfacesAndSelfTo<SelectLeveMenuView>()
			         .FromInstance(_selectLeveMenuView)
			         .AsSingle();
		}
	}
}