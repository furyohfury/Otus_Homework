using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class LevelEntitiesService
	{
		public Transform Container => _container;

		private readonly IEntityWorld _entityWorld;
		private readonly Transform _container;

		public LevelEntitiesService(IEntityWorld entityWorld, Transform container)
		{
			_entityWorld = entityWorld;
			_container = container;
		}

		public IReadOnlyList<IEntity> GetLevelEntities()
		{
			return _entityWorld.GetEntitiesWithTag(TagAPI.LevelEntity);
		}
	}
}