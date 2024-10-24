using Sirenix.OdinInspector;
using UnityEngine;

namespace RealTime
{
	public sealed class OilStorage : MonoBehaviour
	{
		[ShowInInspector]
		public int Amount { get; private set; }

		public void AddOil(int count)
		{
			Amount += count;
		}
	}
}