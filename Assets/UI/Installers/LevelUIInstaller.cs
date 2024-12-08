using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class LevelUIInstaller : MonoInstaller
	{
		[SerializeField]
		private SingleTextFieldView _timerView;
		[SerializeField]
		private Button _playButton;
		[SerializeField]
		private Button _mainMenuStartPanelButton;
		[SerializeField]
		private Button _restartButton;
		[SerializeField]
		private Button _mainMenuPausePanelButton;
		[SerializeField]
		private SingleTextFieldView _leaderboardListView;
		[SerializeField]
		private GameObject _startMenuView;
		[SerializeField]
		private GameObject _pauseMenuView;
		
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<LevelTimerPresenter>()
			         .AsCached()
			         .WithArguments(_timerView);
			Container.BindInterfacesTo<PlayButtonObserver>()
			         .AsCached()
			         .WithArguments(_playButton, _startMenuView);
			Container.BindInterfacesTo<MainMenuButtonObserver>()
			         .AsCached()
			         .WithArguments(_mainMenuStartPanelButton);
			
			Container.BindInterfacesTo<MainMenuButtonObserver>()
			         .AsCached()
			         .WithArguments(_mainMenuPausePanelButton);

			Container.BindInterfacesAndSelfTo<LeaderboardListController>()
			         .AsCached()
			         .WithArguments(_leaderboardListView);
			Container.BindInterfacesAndSelfTo<RestartButtonObserver>()
			         .AsCached()
			         .WithArguments(_restartButton, _startMenuView, _pauseMenuView);
		}
	}
}