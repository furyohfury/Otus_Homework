namespace Game
{
	public sealed class RebindButtonPresenter
	{
		private readonly RebindButtonView _view;
		private readonly InputRebinder _inputRebinder;
		private readonly InputActionsUIData _data;
		private readonly BindPathService _bindPathService;
		private readonly string _scheme;

		public RebindButtonPresenter(RebindButtonView view, InputRebinder inputRebinder, InputActionsUIData data, BindPathService bindPathService
			, string scheme)
		{
			_view = view;
			_inputRebinder = inputRebinder;
			_data = data;
			_bindPathService = bindPathService;
			_scheme = scheme;
		}

		public void Init()
		{
			_view.OnKeyRebindButtonPressed += OnKeyRebindButtonPressed;
			_view.OnResetButtonPressed += OnResetButtonPressed;
			InitializeView();
		}

		private void InitializeView()
		{
			var displayName = _data.ActionDisplayName;
			_view.SetInputActionName(displayName);
			SetCurrentBindText();
		}

		private async void OnKeyRebindButtonPressed()
		{
			var defaultPath = _data.DefaultPath;
			await _inputRebinder.MakeInteractiveRebind(_data.Action, defaultPath);
			SetCurrentBindText();
		}

		private void OnResetButtonPressed()
		{
			var defaultPath = _data.DefaultPath;
			_inputRebinder.RemoveRebind(_data.Action, defaultPath);
			SetCurrentBindText();
		}

		private void SetCurrentBindText()
		{
			var formattedPath = _bindPathService.GetDisplayName(_data.Action, _scheme, _data.DefaultPath);
			_view.SetBindText(formattedPath);
		}
	}
}