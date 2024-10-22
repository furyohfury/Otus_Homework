using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace RealTime
{
	public sealed class ChestSpawner
	{
		private DiContainer _diContainer;
		
		[Inject]
		public ChestSpawner(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}

		public Chest SpawnChest(Chest chest, Vector3 pos, Transform parent)
		{
			var spawnedChest = Object.Instantiate(chest, pos, quaternion.identity, parent);
			spawnedChest.Construct(chest.Rewards, chest.ChestType, chest.Timer);
			foreach (var reward in spawnedChest.Rewards)
			{
				_diContainer.Inject(reward);
			}			
			return spawnedChest;
		}
	}
}