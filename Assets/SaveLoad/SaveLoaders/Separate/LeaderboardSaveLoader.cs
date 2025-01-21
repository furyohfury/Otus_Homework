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
	public sealed class LeaderboardSaveLoader : IInitializable, IDisposable
	{
		private readonly Leaderboard _leaderboard;
		private readonly IGameRepository _gameRepository;

		[Inject]
		public LeaderboardSaveLoader(Leaderboard leaderboard, IGameRepository gameRepository)
		{
			_leaderboard = leaderboard;
			_gameRepository = gameRepository;
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

			var scene = SceneManager.GetActiveScene().name;
			var currentSceneLeaderboard = scenesLeaderboards[scene];
			_leaderboard.SetLeaderboard(currentSceneLeaderboard);
		}

		private void Save()
		{
			var scene = SceneManager.GetActiveScene().name;
			var currentSceneLeaderboard = _leaderboard.Times.ToList();

			if (_gameRepository.TryGetData(out Dictionary<string, List<TimeSpan>> scenesLeaderboards) == false)
			{
				scenesLeaderboards = new Dictionary<string, List<TimeSpan>>();
			}

			if (scenesLeaderboards.TryAdd(scene, currentSceneLeaderboard) == false)
			{
				scenesLeaderboards[scene] = currentSceneLeaderboard;
			}

			_gameRepository.SetData(scenesLeaderboards);
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