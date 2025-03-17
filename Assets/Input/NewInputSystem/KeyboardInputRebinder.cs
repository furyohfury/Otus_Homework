using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class KeyboardInputRebinder : InputRebinder
	{
		private readonly InputControls _inputControls;
		private readonly string _scheme;

		[Inject]
		public KeyboardInputRebinder(InputControls inputControls)
		{
			_inputControls = inputControls;
			_scheme = _inputControls.KeyboardScheme.name;
		}

		[Button]
		private void RebindJump()
		{
			// RebindAction(_inputControls.Gameplay.Jump, "");
			// Rebind(action, "");
		}

		public override async UniTask<string> MakeInteractiveRebind(string action, string oldPath)
		{
			var inputAction = _inputControls.FindAction(action);

			int bindingIndex = inputAction.bindings.IndexOf(b =>
				b.groups != null
				&& b.groups.Contains(_scheme)
				&& b.path == oldPath
			);

			if (bindingIndex == -1)
			{
				Debug.LogError($"Input action for scheme {_scheme} with path: {oldPath} not found");
				inputAction.Enable();
				return null;
			}

			var tcs = new UniTaskCompletionSource<string>();
			string newPath = string.Empty;
			inputAction.Disable();
			inputAction.PerformInteractiveRebinding(bindingIndex)
			           .WithControlsExcluding("<Mouse>, <Gamepad>")
			           .OnComplete(operation =>
			           {
				           inputAction.ApplyBindingOverride(bindingIndex, operation.selectedControl.path);
				           inputAction.Enable();
				           newPath = operation.selectedControl.path;
				           string formattedPath = InputControlPath.ToHumanReadableString(inputAction.bindings[bindingIndex].effectivePath
					           , InputControlPath.HumanReadableStringOptions.OmitDevice);
				           Debug.Log($"New bind for {action} : {formattedPath}");

				           // TODO saving
				           operation.Dispose();
				           tcs.TrySetResult(newPath);
			           })
			           .Start();

			return await tcs.Task;
		}

		[Button]
		public void RemoveJumpRebind()
		{
			InputAction jumpAction = _inputControls.Gameplay.Jump;
			jumpAction.RemoveBindingOverride(0);
		}
	}
}