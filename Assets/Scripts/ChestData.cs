using System;
using UnityEngine;

namespace RealTime
{
	[Serializable]
	public sealed class ChestData
	{
		public ChestTimer Timer;
		[SerializeReference]
		private IReward _reward;
		[SerializeField]
		private ChestType _chestType;

		public void Initialize()
		{
			Timer.Initialize();
		}
	}
}