using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class HealthBarInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private HealthBar _healthBar;

		public override void Install(IEntity entity)
		{
			entity.AddHealthBar(_healthBar);

			entity.AddBehaviour<HealthBarBehaviour>();
		}
	}
}