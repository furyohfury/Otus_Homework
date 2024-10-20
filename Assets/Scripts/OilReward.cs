using UnityEngine;

namespace RealTime
{
	public sealed class OilReward : IReward
	{
		[SerializeField]
		private int _amount;
		[SerializeField]
		private OilStorage _oilStorage;

		void IReward.GetReward()
		{
			_oilStorage.AddOil(_amount);
		}
	}
}