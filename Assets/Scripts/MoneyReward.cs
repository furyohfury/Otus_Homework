using System;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace RealTime
{
	[Serializable]
	public sealed class MoneyReward : IReward
	{
		[SerializeField][JsonProperty]
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