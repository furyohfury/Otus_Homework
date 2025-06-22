using System.Linq;
using Atomic.Entities;
using Game;

namespace SaveLoad
{
	public sealed class WorldEntitiesSaveLoader : SaveLoader<WorldEntitiesData, WorldEntitiesService>
	{
		protected override void SetupData(WorldEntitiesService service, WorldEntitiesData data)
		{
			var projectiles = service.GetWorldEntities().ToArray();
			for (int i = 0, count = projectiles.Length; i < count; i++)
			{
				SceneEntity.Destroy(projectiles[i]);
			}
		}

		protected override WorldEntitiesData ConvertToData(WorldEntitiesService service)
		{
			return default;
		}
	}
}