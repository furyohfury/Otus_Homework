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

		public string GetPath(string action, string scheme = null)
		{
			var inputAction = _inputControls.FindAction(action);
			if (scheme == null)
			{
				return inputAction.bindings[0].path;
			}

			int bindingIndex = 0;
			bindingIndex = inputAction.bindings.IndexOf(b =>
				b.groups != null
				&& b.groups.Contains(scheme));

			return bindingIndex != -1
				? inputAction.bindings[bindingIndex].effectivePath
				: null;
		}

		public string GetFormattedPath(string action, string scheme)
		{
			return InputControlPath.ToHumanReadableString(GetPath(action, scheme), InputControlPath.HumanReadableStringOptions.UseShortNames);
		}
	}
}