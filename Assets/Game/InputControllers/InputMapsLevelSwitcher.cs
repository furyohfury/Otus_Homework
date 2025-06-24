using System;
using Zenject;

namespace Game
{
	public sealed class InputMapsLevelSwitcher : IInitializable, IDisposable
	{
		private readonly InputControls _inputControls;
		private readonly LevelManager _levelManager;

		public InputMapsLevelSwitcher(InputControls inputControls, LevelManager levelManager)
		{
			_inputControls = inputControls;
			_levelManager = levelManager;
		}

		public void Initialize()
		{
			_levelManager.OnLevelStarted += OnLevelStarted;
			_levelManager.OnLevelFinished += OnLevelFinished;
		}

		private void OnLevelStarted()
		{
			SetGameplayMapState(true);
			SetUIMapState(false);
		}

		private void OnLevelFinished()
		{
			SetGameplayMapState(false);
			SetUIMapState(true);
		}

		private void SetGameplayMapState(bool isActive)
		{
			if (isActive)
			{
				_inputControls.Gameplay.Enable();
			}
			else
			{
				_inputControls.Gameplay.Disable();
			}
		}

		private void SetUIMapState(bool isActive)
		{
			if (isActive)
			{
				_inputControls.UI.Enable();
			}
			else
			{
				_inputControls.UI.Disable();
			}
		}

		public void Dispose()
		{
			_levelManager.OnLevelStarted -= OnLevelStarted;
			_levelManager.OnLevelFinished -= OnLevelFinished;
		}
	}
}