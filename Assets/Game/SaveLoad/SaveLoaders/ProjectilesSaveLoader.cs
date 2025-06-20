using Atomic.Entities;

namespace SaveLoad
{
	public sealed class ProjectilesSaveLoader : SaveLoader<ProjectileData, ProjectileService> // TODO unnes: kal tupoy
	{
		protected override ProjectileData ConvertToData(ProjectileService service)
		{
			return default;
		}

		protected override void SetupData(ProjectileService service, ProjectileData data)
		{
			IEntity[] projectiles = service.GetProjectiles();
			for (int i = 0, count = projectiles.Length; i < count; i++)
			{
				SceneEntity.Destroy(projectiles[i]);
			}
		}
	}
}