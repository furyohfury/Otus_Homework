using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public sealed class MoneyStorage : MonoBehaviour
	{
		[ShowInInspector]
		public int Amount { get; private set; }

		public void AddMoney(int count)
		{
			Amount += count;
		}
	}
}