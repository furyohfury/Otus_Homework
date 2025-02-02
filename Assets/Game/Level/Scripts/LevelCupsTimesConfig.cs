using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "LevelCupsTimesConfig", menuName = "Create config/Level Cups Times")]
	public sealed class LevelCupsTimesConfig : SerializedScriptableObject
	{
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
	}
}