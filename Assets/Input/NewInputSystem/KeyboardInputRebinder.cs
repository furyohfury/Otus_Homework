using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public sealed class KeyboardInputRebinder : InputRebinder
	{
		private readonly InputControls _inputControls;
		private readonly string _scheme;

		public KeyboardInputRebinder(InputControls inputControls, IRebindSaveLoader rebindSaveLoader) : base(rebindSaveLoader)
		{
			_inputControls = inputControls;
			_scheme = _inputControls.KeyboardScheme.name;
		}

		protected override async UniTask<string> Rebind(string action, string defaultPath)
		{
			var bindingIndex = GetBindingIndex(action, defaultPath, out var inputAction);

			if (bindingIndex == -1)
			{
#if UNITY_EDITOR
				Debug.LogError($"Input action for scheme {_scheme} with path: {defaultPath} not found");
#endif
				inputAction.Enable();
				return null;
			}

			var tcs = new UniTaskCompletionSource<string>();
			string newPath = string.Empty;
			inputAction.Disable();
			inputAction.PerformInteractiveRebinding(bindingIndex)
			           .WithControlsExcluding("<Gamepad>")
			           .OnComplete(operation =>
			           {
				           inputAction.ApplyBindingOverride(bindingIndex, operation.selectedControl.path);
				           inputAction.Enable();
				           newPath = operation.selectedControl.path;
#if UNITY_EDITOR
				           string formattedPath = InputControlPath.ToHumanReadableString(inputAction.bindings[bindingIndex].effectivePath
					           , InputControlPath.HumanReadableStringOptions.OmitDevice);
				           Debug.Log($"New bind for {action} : {formattedPath}");
#endif
				           operation.Dispose();
				           tcs.TrySetResult(newPath);
			           })
			           .Start();

			return await tcs.Task;
		}

		private int GetBindingIndex(string action, string defaultPath, out InputAction inputAction)
		{
			inputAction = _inputControls.FindAction(action);

			int bindingIndex = inputAction.bindings.IndexOf(b =>
				b.groups != null
				&& b.groups.Contains(_scheme)
				&& b.path == defaultPath
			);
			return bindingIndex;
		}

		protected override void RemoveBindOverride(string action, string defaultPath)
		{
			var bindingIndex = GetBindingIndex(action, defaultPath, out InputAction inputAction);
			if (bindingIndex != -1)
			{
				inputAction.RemoveBindingOverride(bindingIndex);
			}
		}
	}
}