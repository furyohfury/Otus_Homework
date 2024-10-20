using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public sealed class MoneyStorage : MonoBehaviour
	{
		[ShowInInspector]
		public int Amount => _amount;
		private int _amount;

		public void AddMoney(int count) => _amount += count;
		public void SpendMoney(int count) => _amount -= count;
	}
}