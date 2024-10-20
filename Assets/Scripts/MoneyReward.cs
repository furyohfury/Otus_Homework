using UnityEngine;
using Zenject;

namespace RealTime
{
	public sealed class MoneyReward : IReward
	{
		[SerializeField]
		private int _amount;
		private MoneyStorage _moneyStorage;

		[Inject]
		private void Construct(MoneyStorage moneyStorage)
		{
			_moneyStorage = moneyStorage;
		}

		void IReward.GetReward()
		{
			_moneyStorage.AddMoney(_amount);
		}
	}
}