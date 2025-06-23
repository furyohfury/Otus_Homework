using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class UIInputReader : InputControls.IUIActions, IInitializable, IDisposable
	{
		public event Action OnPaused;
		private readonly InputControls _inputControls;

		public UIInputReader(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		public void Initialize()
		{
			_inputControls.UI.SetCallbacks(this);
		}

		void InputControls.IUIActions.OnPause(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed)
			{
				OnPaused?.Invoke();
			}
		}

		public void Dispose()
		{
			_inputControls.UI.Disable();
		}
	}
}