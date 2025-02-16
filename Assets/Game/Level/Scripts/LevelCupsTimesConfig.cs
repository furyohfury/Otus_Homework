using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelCupsTimesConfig", menuName = "Create config/Level Cups Times")]
	public sealed class LevelCupsTimesConfig : SerializedScriptableObject
	{
		public string LevelName => _levelName;

		[SerializeField]
		private string _levelName;

		[SerializeField]
		private Dictionary<Cups, int> _targetTimeInSeconds;

		public Dictionary<Cups, TimeSpan> GetTargetTimes()
		{
			var times = new Dictionary<Cups, TimeSpan>();
			foreach (KeyValuePair<Cups, int> pair in _targetTimeInSeconds)
			{
				var time = TimeSpan.FromSeconds(pair.Value);
				times.Add(pair.Key, time);
			}

			return times;
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (string.IsNullOrEmpty(_levelName) == false
			    && EditorBuildSettings.scenes.Any(scene => scene.path == string.Concat("Assets/", "Scenes/", _levelName, ".unity")) == false)
			{
				Debug.LogError($"No scene with name: {_levelName}");
			}
		}
#endif
	}
}