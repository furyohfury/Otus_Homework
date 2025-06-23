using System;
using Zenject;

namespace Game
{
	public sealed class InputMapsSwitcher : IInitializable, IDisposable
	{
		private readonly InputControls _inputControls;
		private readonly GameStateManager _gameStateManager;

		public InputMapsSwitcher(InputControls inputControls, GameStateManager gameStateManager)
		{
			_inputControls = inputControls;
			_gameStateManager = gameStateManager;
		}

		public void Initialize()
		{
			_gameStateManager.OnStateChanged += OnStateChanged;
#if UNITY_EDITOR
			_inputControls.Gameplay.Enable();
#else
			_inputControls.UI.Enable();
#endif
		}

		private void OnStateChanged(GameState state)
		{
			if (state is GameState.Pause or GameState.Finish)
			{
				SetGameplayMapState(false);
				SetUIMapState(true);
			}
			else
			{
				SetGameplayMapState(true);
				SetUIMapState(false);
			}
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
			_gameStateManager.OnStateChanged -= OnStateChanged;
		}
	}
}