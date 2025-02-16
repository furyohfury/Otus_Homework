using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public sealed class LevelData
	{
		public Scene Scene;
		public string Name;
		public Dictionary<Cups, List<TimeSpan>> CupsTargetTimes;
		public List<TimeSpan> Results;
	}
}