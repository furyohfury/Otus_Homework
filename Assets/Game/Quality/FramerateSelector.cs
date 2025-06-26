using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
	public sealed class FramerateSelector : IInitializable, ITickable
	{
		public void Initialize()
		{
			Application.targetFrameRate = 30;
		}

		public void Tick()
		{
			if (Keyboard.current.numpad0Key.wasPressedThisFrame)
			{
				QualitySettings.SetQualityLevel(0);
			}
			else if (Keyboard.current.numpad1Key.wasPressedThisFrame)
			{
				QualitySettings.SetQualityLevel(1);
			}
			else if (Keyboard.current.numpad2Key.wasPressedThisFrame)
			{
				QualitySettings.SetQualityLevel(2);
			}
		}
	}
}