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

		public event Action OnLevelReset;

		private readonly IWinCondition[] _winConditions;
		private readonly FinishLine _finishLine;
		private readonly SaveLoadManager _saveLoadManager;
		private readonly LevelTimer _levelTimer;
		private readonly GameStateManager _gameStateManager;

		[Inject]
		public LevelManager(IWinCondition[] winConditions, FinishLine finishLine, LevelTimer levelTimer, SaveLoadManager saveLoadManager, GameStateManager gameStateManager)
		{
			_winConditions = winConditions;
			_finishLine = finishLine;
			_levelTimer = levelTimer;
			_saveLoadManager = saveLoadManager;
			_gameStateManager = gameStateManager;
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
			_gameStateManager.ChangeState(GameState.Start);
			OnLevelStarted?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level started");
#endif
		}

		public void ResetLevel()
		{
			_saveLoadManager.Load();
			_levelTimer.Finish();
			_levelTimer.Reset();
			_gameStateManager.ChangeState(GameState.Pause);
			OnLevelReset?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level reset");
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
			_gameStateManager.ChangeState(GameState.Pause);
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