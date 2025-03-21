using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public sealed class XboxGamepadInputRebinder : InputRebinder
	{
		private readonly InputControls _inputControls;
		private readonly string _scheme;

		public XboxGamepadInputRebinder(InputControls inputControls, IRebindSaveLoader rebindSaveLoader) : base(rebindSaveLoader)
		{
			_inputControls = inputControls;
			_scheme = _inputControls.XboxGamepadScheme.name;
		}

		protected override async UniTask<string> Rebind(string action, string oldPath)
		{
			var inputAction = _inputControls.FindAction(action);

			int bindingIndex = inputAction.bindings.IndexOf(b =>
				b.groups != null
				&& b.groups.Contains(_scheme)
				&& b.path == oldPath
			);

			if (bindingIndex == -1)
			{
#if UNITY_EDITOR
				Debug.LogError($"Input action for scheme {_scheme} with path: {oldPath} not found");
#endif
				inputAction.Enable();
				return null;
			}

			var tcs = new UniTaskCompletionSource<string>();
			string newPath = string.Empty;
			inputAction.Disable();
			inputAction.PerformInteractiveRebinding(bindingIndex)
			           .WithControlsExcluding("<Mouse>, <Keyboard>")
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
				           // TODO saving
				           operation.Dispose();
				           tcs.TrySetResult(newPath);
			           })
			           .Start();

			return await tcs.Task;
		}

		public void RemoveRebind()
		{
			InputAction jumpAction = _inputControls.Gameplay.Jump;
			jumpAction.RemoveBindingOverride(0);
		}
	}
}