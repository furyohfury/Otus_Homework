using System;
using System.Linq;
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

		[Inject]
		public LevelManager(IWinCondition[] winConditions, FinishLine finishLine)
		{
			_winConditions = winConditions;
			_finishLine = finishLine;
		}

		public void Initialize()
		{
			_finishLine.OnCrossed += CheckWinConditions;
		}

		public void StartLevel()
		{
			OnLevelStarted?.Invoke();
		}

		public void RestartLevel()
		{
			// TODO 
			StartLevel();
		}

		private void CheckWinConditions()
		{
			if (_winConditions.All(cond => cond.IsMet))
			{
				OnLevelFinished?.Invoke();
			}

			FinishLevel();
		}

		private void FinishLevel()
		{
			Debug.Log("Level end");
		}

		public void Dispose()
		{
			_finishLine.OnCrossed -= CheckWinConditions;
		}
	}
}