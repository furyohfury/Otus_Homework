using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using ObservableCollections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace SaveLoad
{
	public sealed class LeaderboardSaveController : IInitializable, IDisposable
	{
		private readonly Leaderboard _leaderboard;
		private readonly IGameRepository _gameRepository;
		private string _sceneName;

		[Inject]
		public LeaderboardSaveController(Leaderboard leaderboard, IGameRepository gameRepository)
		{
			_leaderboard = leaderboard;
			_gameRepository = gameRepository;
			_sceneName = SceneManager.GetActiveScene().name;
		}

		public void Initialize()
		{
			_leaderboard.Times.CollectionChanged += OnTimesChanged;
			LoadLeaderboards();
		}

		private void LoadLeaderboards()
		{
			if (_gameRepository.TryGetData(out Dictionary<string, List<TimeSpan>> scenesLeaderboards) == false)
			{
				Debug.LogWarning("Couldn't find leaderboards data");
				return;
			}

			var currentSceneLeaderboard = scenesLeaderboards[_sceneName];
			_leaderboard.SetLeaderboard(currentSceneLeaderboard);
		}

		private void Save()
		{
			var currentSceneLeaderboard = _leaderboard.Times.ToList();

			if (_gameRepository.TryGetData(out Dictionary<string, List<TimeSpan>> scenesLeaderboards) == false)
			{
				scenesLeaderboards = new Dictionary<string, List<TimeSpan>>();
			}

			scenesLeaderboards[_sceneName] = currentSceneLeaderboard;

			_gameRepository.SetData(scenesLeaderboards);
			_gameRepository.SaveState();
		}

		private void OnTimesChanged(in NotifyCollectionChangedEventArgs<TimeSpan> _)
		{
			Save();
		}

		public void Dispose()
		{
			_leaderboard.Times.CollectionChanged -= OnTimesChanged;
		}
	}
}