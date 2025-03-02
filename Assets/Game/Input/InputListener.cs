using System;
using UnityEngine;
using Zenject;
using ITickable = Zenject.ITickable;

namespace Game
{
	public sealed class InputListener : ITickable // doesnt need to be paused
	{
		public event Action<InputCommand> OnCommand;

		private InputData[] Data => _inputMap.Data;
		private readonly InputMap _inputMap;

		[Inject]
		public InputListener(InputMap inputMap)
		{
			_inputMap = inputMap;
		}

		public void Tick()
		{
			HandleButtons();
		}
		
		public Vector3 GetMousePosition()
		{
			return Input.mousePosition;
		}

		private void HandleButtons()
		{
			for (int i = 0, count = Data.Length; i < count; i++)
			{
				var data = Data[i];
				if (data.CheckInput())
				{
					OnCommand?.Invoke(data.Command);
				}
			}
		}
	}
}