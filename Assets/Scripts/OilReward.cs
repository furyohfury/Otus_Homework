using System;
using UnityEngine;
using Zenject;

namespace RealTime
{
	[Serializable]
	public sealed class OilReward : IReward
	{
		[SerializeField]
		private int _amount;
		private OilStorage _oilStorage;
		
		[Inject]
		public void Construct(OilStorage oilStorage)
		{
			_oilStorage = oilStorage;
		}

		void IReward.GetReward()
		{
			_oilStorage.AddOil(_amount);
		}
	}
}