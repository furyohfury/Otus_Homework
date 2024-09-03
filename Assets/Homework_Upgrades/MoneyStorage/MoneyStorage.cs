using System;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
	public class MoneyStorage : MonoBehaviour, IMoneyStorage
	{
		public event Action<int> OnMoneyChanged;
		public event Action<int> OnMoneyEarned;
		public event Action<int> OnMoneySpent;
		public int Money { get; private set; }

		public void EarnMoney(int amount)
		{
			Money += amount;
		}

		public void SpendMoney(int amount)
		{
			Money -= amount;
		}

		public bool CanSpendMoney(int amount)
		{
			var result = amount <= Money;
			Debug.Log($"Can spend {amount} of all money {Money} = {result}");
			return result;
		}
	}
}