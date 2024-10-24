using System;

namespace RealTime
{
	[Serializable]
	public sealed class ChestData
	{
		public ChestTimer Timer;
		public IReward[] Rewards;
		public ChestType ChestType;

		public ChestData(ChestTimer timer, IReward[] rewards, ChestType chestType)
		{
			Timer = timer;
			Rewards = rewards;
			ChestType = chestType;
		}
	}
}