using System;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace RealTime
{
	[Serializable]
	public sealed class OilReward : IReward
	{
		[SerializeField] [JsonProperty]
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