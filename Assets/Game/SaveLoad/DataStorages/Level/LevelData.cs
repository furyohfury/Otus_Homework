using System;
using System.Collections.Generic;

namespace SaveLoad
{
	public sealed class LevelData
	{
		public string Name;
		public List<TimeSpan> Results;

		public LevelData(string name, List<TimeSpan> results = null)
		{
			Name = name;
			Results = results;
		}
	}
}