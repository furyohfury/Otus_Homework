using UnityEngine;
using Zenject;

namespace UI
{
	public sealed class SelectLevelMenuInstaller : MonoInstaller
	{
		[SerializeField]
		private LevelCardView _levelCardViewPrefab;
		[SerializeField] [Space]
		private LevelCardCupSprites _cupSprites;
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
			Container.BindInterfacesAndSelfTo<LevelCardPresenterFactory>()
			         .AsCached()
			         .WithArguments(_cupSprites.CupSprites);

			Container.BindInterfacesAndSelfTo<LevelCardViewFactory>()
			         .AsCached()
			         .WithArguments(_levelCardViewPrefab);
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