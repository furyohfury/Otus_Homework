using UnityEngine.InputSystem;

namespace Game
{
	public sealed class BindPathService
	{
		private readonly InputControls _inputControls;

		public BindPathService(InputControls inputControls)
		{
			_inputControls = inputControls;
		}

		public string GetDefaultPath(string action, string scheme)
		{
			var bindingIndex = GetBindingIndex(action, scheme, out var inputAction);
			return bindingIndex != -1
				? inputAction.bindings[bindingIndex].path
				: null;
		}

		public string GetPath(string action, string scheme)
		{
			var bindingIndex = GetBindingIndex(action, scheme, out var inputAction);

			return bindingIndex != -1
				? inputAction.bindings[bindingIndex].effectivePath
				: null;
		}

		public string GetDisplayName(string action, string scheme, string defaultPath = null)
		{
			var bindingIndex = GetBindingIndex(action, scheme, out var inputAction, defaultPath);

			return bindingIndex != -1
				? inputAction.GetBindingDisplayString(bindingIndex)
				: null;
		}

		private int GetBindingIndex(string action, string scheme, out InputAction inputAction, string defaultPath = null)
		{
			inputAction = _inputControls.FindAction(action);

			int bindingIndex = inputAction.bindings.IndexOf(b =>
				b.groups != null
				&& b.groups.Contains(scheme)
				&& (defaultPath == null || b.path == defaultPath));
			return bindingIndex;
		}
	}
}