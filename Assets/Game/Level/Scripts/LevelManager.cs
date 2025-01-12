using System;
using System.Collections;
using System.Linq;
using Atomic.Entities;
using SaveLoad;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class LevelManager : IInitializable, IDisposable
	{
		public event Action OnLevelStarted;
		public event Action OnLevelFinished;

		private readonly IWinCondition[] _winConditions;
		private readonly FinishLine _finishLine;
		private readonly SaveLoadManager _saveLoadManager;
		private readonly LevelTimer _levelTimer;
		private readonly IEntity _character;

		[Inject]
		public LevelManager(IWinCondition[] winConditions, FinishLine finishLine, LevelTimer levelTimer
			, IEntity character, SaveLoadManager saveLoadManager)
		{
			_winConditions = winConditions;
			_finishLine = finishLine;
			_levelTimer = levelTimer;
			_character = character;
			_saveLoadManager = saveLoadManager;
		}

		public void Initialize()
		{
			_finishLine.OnCrossed += CheckWinConditions;
			// _gameRepository.SaveState();
		}

		public void StartLevel()
		{
			_saveLoadManager.Save();
			_levelTimer.Start();
			_character.Enable();
			OnLevelStarted?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level started");
#endif
		}

		public void RestartLevel()
		{
			_saveLoadManager.Load();
			StartLevel();
#if UNITY_EDITOR
			Debug.Log("Level restarted");
#endif
		}

		private void CheckWinConditions()
		{
			if (_winConditions.All(cond => cond.IsMet))
			{
				OnLevelFinished?.Invoke();
			}

			FinishLevel();
		}

		public void FinishLevel()
		{
			_character.Disable();
			OnLevelFinished?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level finished");
#endif
		}

		public void Dispose()
		{
			_finishLine.OnCrossed -= CheckWinConditions;
		}
	}
}