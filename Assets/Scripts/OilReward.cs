using UnityEngine;
using Zenject;

namespace RealTime
{
	public sealed class OilReward : IReward
	{
		[SerializeField]
		private int _amount;
		private OilStorage _oilStorage;
		
		[Inject]
		private void Construct(OilStorage oilStorage)
		{
			_oilStorage = oilStorage;
		}

		void IReward.GetReward()
		{
			_oilStorage.AddOil(_amount);
		}
	}
}