using System;
using UnityEngine;
using Zenject;

namespace RealTime
{
	[Serializable]
	public sealed class MoneyReward : IReward
	{
		[SerializeField]
		private int _amount;
		private MoneyStorage _moneyStorage;

		[Inject]
		public void Construct(MoneyStorage moneyStorage)
		{
			_moneyStorage = moneyStorage;
		}
		
		void IReward.GetReward()
		{
			_moneyStorage.AddMoney(_amount);
		}
	}
}