using System;
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
		private readonly IEntityWorld _entityWorld;
		private readonly EnemyService _enemyService;

		[Inject]
		public LevelManager(IWinCondition[] winConditions, FinishLine finishLine, LevelTimer levelTimer, SaveLoadManager saveLoadManager,
			IEntityWorld entityWorld, EnemyService enemyService)
		{
			_winConditions = winConditions;
			_finishLine = finishLine;
			_levelTimer = levelTimer;
			_saveLoadManager = saveLoadManager;
			_entityWorld = entityWorld;
			_enemyService = enemyService;
		}

		public void Initialize()
		{
			_finishLine.OnCrossed += CheckWinConditions;
			_saveLoadManager.LoadSpecific<LevelResultsSaveLoader>();
			_saveLoadManager.Save();
			_entityWorld.DisableEntities();
		}

		public void StartLevel()
		{
			// _saveLoadManager.Save();
			_levelTimer.Start();
			_entityWorld.EnableEntities();
			OnLevelStarted?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level started");
#endif
		}

		public void PauseLevel()
		{
			_levelTimer.Pause();
			_entityWorld.DisableEntities();
		}

		public void ResumeLevel()
		{
			_levelTimer.Resume();
			_entityWorld.EnableEntities();
		}

		public void ResetLevel()
		{
			_saveLoadManager.Load();
			_levelTimer.Finish();
			_levelTimer.Reset();
			_entityWorld.DisableEntities();
			_enemyService.Reset();
			OnLevelReset?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level reset");
#endif
		}

		public void FinishLevel()
		{
			_entityWorld.DisableEntities();
			_levelTimer.Finish();
			_saveLoadManager.SaveSpecific<LevelResultsSaveLoader>();
			OnLevelFinished?.Invoke();
#if UNITY_EDITOR
			Debug.Log("Level finished");
#endif
		}

		private void CheckWinConditions()
		{
			if (_winConditions.All(cond => cond.IsMet))
			{
				FinishLevel();
			}
		}

		public void Dispose()
		{
			_finishLine.OnCrossed -= CheckWinConditions;
		}
	}
}