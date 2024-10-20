using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public sealed class OilStorage : MonoBehaviour
	{
		[ShowInInspector]
		public int Amount => _amount;

		private int _amount;

		public void AddOil(int count) => _amount += count;
		public void SpendOil(int count) => _amount -= count;
	}
}