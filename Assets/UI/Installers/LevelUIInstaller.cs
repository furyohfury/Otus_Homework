using System.Linq;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public sealed class LevelUIInstaller : MonoInstaller
	{
		[SerializeField]
		private AmountView _timerView;
		[SerializeField]
		private Button _playButton;
		[SerializeField]
		private Button _mainMenuStartPanelButton;
		[SerializeField]
		private Button _restartButton;
		[SerializeField]
		private Button _mainMenuPausePanelButton;
		[SerializeField]
		private AmountView _leaderboardListView;
		[SerializeField]
		private StartLevelMenuView _startMenuView;
		[SerializeField]
		private PauseMenuView _pauseMenuView;
		[SerializeField] 
		private GameOverMenuView _gameOverMenuView;
		[SerializeField]
		private FinishLevelMenuView _finishLevelMenuView;

		[SerializeField]
		private SceneEntity _character;


		public override void InstallBindings()
		{
			Container.BindInterfacesTo<LevelTimerPresenter>()
			         .AsCached()
			         .WithArguments(_timerView);
			
			// Container.BindInterfacesAndSelfTo<LeaderboardListController>()
			//          .AsCached()
			//          .WithArguments(_leaderboardListView);

			InstallLevelMenus();
		}

		private void InstallLevelMenus()
		{
			Container.BindInterfacesTo<StartLevelMenuPresenter>()
			         .AsCached()
			         .WithArguments(_startMenuView);
			
			Container.BindInterfacesTo<GameOverMenuPresenter>()
			         .AsCached()
			         .WithArguments(_gameOverMenuView, _character);
			
			Container.BindInterfacesTo<PauseMenuPresenter>()
			         .AsCached()
			         .WithArguments(_pauseMenuView);

			Container.BindInterfacesTo<FinishLevelMenuPresenter>()
			         .AsCached()
			         .WithArguments(_finishLevelMenuView);
		}
	}
}