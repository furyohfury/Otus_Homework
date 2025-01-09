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
		private IGameRepository _gameRepository;

		[Inject]
		public LevelManager(IWinCondition[] winConditions, FinishLine finishLine, IGameRepository gameRepository)
		{
			_winConditions = winConditions;
			_finishLine = finishLine;
			_gameRepository = gameRepository;
		}

		public void Initialize()
		{
			_finishLine.OnCrossed += CheckWinConditions;
			_gameRepository.Save();
		}

		public void StartLevel()
		{
			OnLevelStarted?.Invoke();
		}

		public void RestartLevel()
		{
			// TODO 
			_gameRepository.Load();
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