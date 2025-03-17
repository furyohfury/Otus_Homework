using UnityEngine.InputSystem;

namespace Game
{
	public sealed class RebindButtonPresenter
	{
		private readonly RebindButtonView _view;
		private readonly InputRebinder _inputRebinder;
		private readonly InputActionsUIData _data;

		public RebindButtonPresenter(RebindButtonView view, InputRebinder inputRebinder, InputActionsUIData data)
		{
			_view = view;
			_inputRebinder = inputRebinder;
			_data = data;
		}

		public void Init()
		{
			_view.OnKeyRebindButtonPressed += OnKeyRebindButtonPressed;
			_view.OnResetButtonPressed += OnResetButtonPressed;
		}

		private async void OnKeyRebindButtonPressed()
		{
			var newPath = await _inputRebinder.MakeInteractiveRebind(_data.Action, _data.Path);
			var formattedPath = InputControlPath.ToHumanReadableString(newPath, InputControlPath.HumanReadableStringOptions.OmitDevice);
			_view.SetBindText(formattedPath);
		}

		private void OnResetButtonPressed()
		{
		}
	}
}