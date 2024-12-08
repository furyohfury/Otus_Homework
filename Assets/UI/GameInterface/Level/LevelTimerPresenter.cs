using System;
using Game;
using R3;
using Zenject;

namespace UI
{
	public sealed class LevelTimerPresenter : IInitializable, IDisposable
	{
		private readonly SingleTextFieldView _timerView;
		private readonly LevelTimer _levelTimer;
		private readonly CompositeDisposable _compositeDisposable = new();

		[Inject]
		public LevelTimerPresenter(SingleTextFieldView timerView, LevelTimer levelTimer)
		{
			_timerView = timerView;
			_levelTimer = levelTimer;
		}

		public void Initialize()
		{
			Observable.EveryUpdate()
			          .Subscribe(_ => UpdateTimerView())
			          .AddTo(_compositeDisposable);
		}

		private void UpdateTimerView()
		{
			var text = _levelTimer.LevelTime.ToString(@"mm\:ss\:fff");
			_timerView.SetText(text);
		}


		public void Dispose()
		{
			_compositeDisposable.Dispose();
		}
	}
}