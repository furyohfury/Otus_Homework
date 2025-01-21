using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game;
using Newtonsoft.Json;
using ObservableCollections;
using UnityEngine;
using UnityEngine.SceneManagement;
using IInitializable = Zenject.IInitializable;

namespace SaveLoad
{
	public sealed class LeaderboardSaveLoader : IInitializable, IDisposable
	{
		private readonly Leaderboard _leaderboard;
		private readonly string _savePath = Path.Combine(Application.persistentDataPath, "Leaderboards.json");

		public LeaderboardSaveLoader(Leaderboard leaderboard)
		{
			_leaderboard = leaderboard;
		}

		public void Initialize()
		{
			_leaderboard.Times.CollectionChanged += OnTimesChanged;
			LoadLeaderboards();
		}

		private void LoadLeaderboards()
		{
			var saveFile = File.ReadAllText(_savePath);
			Dictionary<string, List<TimeSpan>> savedLeaderboard = JsonConvert.DeserializeObject<Dictionary<string, List<TimeSpan>>>(saveFile);
			var scene = SceneManager.GetActiveScene().name;
			var currentSceneLeaderboard = savedLeaderboard[scene];
			_leaderboard.SetLeaderboard(currentSceneLeaderboard);
		}

		private void Save()
		{
			var saveFile = File.ReadAllText(_savePath);
			Dictionary<string, List<TimeSpan>> savedLeaderboard = JsonConvert.DeserializeObject<Dictionary<string, List<TimeSpan>>>(saveFile);
			var scene = SceneManager.GetActiveScene().name;
			var currentSceneLeaderboard = _leaderboard.Times.ToList();

			if (savedLeaderboard.TryAdd(scene, currentSceneLeaderboard) == false)
			{
				savedLeaderboard[scene] = currentSceneLeaderboard;
			}
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