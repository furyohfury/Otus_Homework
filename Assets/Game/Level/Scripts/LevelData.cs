using System;
using System.Collections.Generic;

namespace Game
{
	public sealed class LevelData
	{
		public string Name;
		public Dictionary<Cups, List<TimeSpan>> CupsTargetTimes;
		public List<TimeSpan> Results;
	}
}