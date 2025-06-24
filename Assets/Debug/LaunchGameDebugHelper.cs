using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace GameDebug
{
	public sealed class LaunchGameDebugHelper : MonoBehaviour
	{
		private LevelManager _levelManager;

		[Inject]
		public void Construct(LevelManager levelManager)
		{
			_levelManager = levelManager;
		}

		private void Update()
		{
			if (Keyboard.current.gKey.wasPressedThisFrame)
			{
				_levelManager.StartLevel();
			}
		}
	}
}