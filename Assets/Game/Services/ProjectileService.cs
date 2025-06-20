using System.Linq;
using Atomic.Entities;

namespace SaveLoad
{
	public sealed class ProjectileService
	{
		private readonly IEntityWorld _entityWorld;

		public ProjectileService(IEntityWorld entityWorld)
		{
			_entityWorld = entityWorld;
		}

		public IEntity[] GetProjectiles()
		{
			return _entityWorld.GetEntitiesWithTag(TagAPI.Bullet).ToArray();
		}
	}
}