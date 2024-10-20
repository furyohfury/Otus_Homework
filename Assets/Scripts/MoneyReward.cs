using UnityEngine;

namespace RealTime
{
	public sealed class MoneyReward : IReward
	{
		[SerializeField]
		private int _amount;
		[SerializeField]
		private MoneyStorage _moneyStorage;

		void IReward.GetReward()
		{
			_moneyStorage.AddMoney(_amount);
		}
	}
}