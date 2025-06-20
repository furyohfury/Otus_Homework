using System.Collections.Generic;
using Atomic.Entities;

namespace Game
{
	public sealed class WorldEntitiesService
	{
		private readonly IEntityWorld _entityWorld;

		public WorldEntitiesService(IEntityWorld entityWorld)
		{
			_entityWorld = entityWorld;
		}

		public IReadOnlyList<IEntity> GetWorldEntities()
		{
			return _entityWorld.GetEntitiesWithTag(TagAPI.WorldEntity);
		}
	}
}