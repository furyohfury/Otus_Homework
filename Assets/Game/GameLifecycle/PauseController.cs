using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PauseController : ITickable // TODO po horoshemu sdelat manager no hz po vremeni((
	{
		private readonly SceneEntityWorld _entityWorld;
		private readonly LevelTimer _levelTimer;
		private bool _isPaused;
		private readonly GameObject _pauseMenuView;

		[Inject]
		public PauseController(SceneEntityWorld entityWorld, LevelTimer levelTimer, GameObject pauseMenuView)
		{
			_entityWorld = entityWorld;
			_levelTimer = levelTimer;
			_pauseMenuView = pauseMenuView;
		}

		public void Tick()
		{
			if (!Input.GetKeyDown(KeyCode.Escape))
			{
				return;
			}

			if (_isPaused)
			{
				OnResume();
			}
			else
			{
				OnPause();
			}

			_isPaused = !_isPaused;
		}

		private void OnPause()
		{
			foreach (var entity in _entityWorld.Entities)
			{
				entity.Disable();
			}

			_levelTimer.PauseTimer();
			_pauseMenuView.SetActive(true);
		}

		public void OnResume()
		{
			foreach (var entity in _entityWorld.Entities)
			{
				entity.Enable();
			}

			_levelTimer.ResumeTimer();
			_pauseMenuView.SetActive(false);
		}
	}
}