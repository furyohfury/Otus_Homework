using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class InputData
	{
		[EnumToggleButtons]
		public InputMode Mode;

		[EnableIf("@this.Mode == InputMode.Hold || this.Mode == InputMode.Press")]
		public KeyCode Key;

		[EnableIf("Mode", InputMode.Axis)]
		public KeyCode[] Axis = new KeyCode[2];

		[SerializeReference]
		public InputCommand Command;

		public bool CheckInput()
		{
			switch (Mode)
			{
				case InputMode.Press:
					if (Input.GetKeyDown(Key))
					{
						return true;
					}

					break;
				case InputMode.Hold:
					if (Input.GetKey(Key))
					{
						return true;
					}

					break;
				case InputMode.Axis:
					var left = Input.GetKey(Axis[0]);
					var right = Input.GetKey(Axis[1]);
					if (left ^ right)
					{
						Command.AxisValue = left
							? -1
							: 1;
					}
					else
					{
						Command.AxisValue = 0f;
					}

					return true;
			}

			return false;
		}
	}
}