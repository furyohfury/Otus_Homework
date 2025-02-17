using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelCupsTimesConfig", menuName = "Create config/Level Cups Times")]
	public sealed class LevelConfig : SerializedScriptableObject
	{
		public string LevelName => _levelName;
		public string SceneName => _sceneName;
		public bool HasTargetTimes => _hasTargetTimes;
		public Sprite Icon => _previewIcon;

		[SerializeField]
		private string _levelName;

		[SerializeField]
		private string _sceneName;

		[SerializeField] [PreviewField]
		private Sprite _previewIcon;

		[SerializeField]
		private bool _hasTargetTimes;

		[SerializeField] [ShowIf("_hasTargetTimes")]
		private Dictionary<Cups, int> _targetTimeInSeconds;

		public bool TryGetLevelTargetTimes(out Dictionary<Cups, TimeSpan> targetTimes)
		{
			if (_hasTargetTimes == false)
			{
				targetTimes = default;
				return false;
			}

			targetTimes = new Dictionary<Cups, TimeSpan>();
			foreach (KeyValuePair<Cups, int> kvp in _targetTimeInSeconds)
			{
				var time = TimeSpan.FromSeconds(kvp.Value);
				targetTimes.Add(kvp.Key, time);
			}

			return true;
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (string.IsNullOrEmpty(_levelName) == false
			    && EditorBuildSettings.scenes.Any(
					scene => scene.path == string.Concat("Assets/", "Scenes/", _levelName, ".unity")) == false)
			{
				Debug.LogError($"No scene with name: {_levelName}");
			}
		}
#endif
	}
}