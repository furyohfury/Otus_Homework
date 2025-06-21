using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class HealthBarInstaller : IEntityInstaller
	{
		[SerializeField]
		private HealthBar _healthBar;

		public void Install(IEntity entity)
		{
			entity.AddHealthBar(_healthBar);
		}
	}
}