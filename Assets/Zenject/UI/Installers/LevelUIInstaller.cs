using Atomic.Entities;
using UnityEngine;
using UnityEngine.Serialization;
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
		[FormerlySerializedAs("_cupsListView")] [SerializeField]
		private FinishLevelCupsListView _finishLevelCupsListView;
		[SerializeField]
		private AmountView _enemyCount;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<LevelTimerPresenter>()
			         .AsCached()
			         .WithArguments(_timerView);

			InstallLevelMenus();

			Container.BindInterfacesTo<LeaderboardPresenter>()
			         .AsCached()
			         .WithArguments(_startMenuView.LeaderboardView);

			Container.BindInterfacesTo<LeaderboardPresenter>()
			         .AsCached()
			         .WithArguments(_finishLevelMenuView.LeaderboardView);

			Container.Bind<FinishLevelCupsListView>()
			         .FromInstance(_finishLevelCupsListView)
			         .AsSingle();

			Container.BindInterfacesTo<FinishLevelCupsListPresenter>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<CharacterDeathUIObserver>()
			         .AsSingle()
			         .WithArguments(_gameOverMenuView);

			Container.BindInterfacesAndSelfTo<EnemyCountUIController>()
			         .AsSingle()
			         .WithArguments(_enemyCount);
		}

		private void InstallLevelMenus()
		{
			Container.BindInterfacesTo<StartLevelMenuPresenter>()
			         .AsCached()
			         .WithArguments(_startMenuView);

			Container.BindInterfacesTo<GameOverMenuPresenter>()
			         .AsCached()
			         .WithArguments(_gameOverMenuView);

			Container.BindInterfacesTo<PauseMenuPresenter>()
			         .AsCached()
			         .WithArguments(_pauseMenuView);

			Container.BindInterfacesTo<FinishLevelMenuPresenter>()
			         .AsCached()
			         .WithArguments(_finishLevelMenuView);
		}
	}
}