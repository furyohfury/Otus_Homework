using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class WeaponVFXInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private AnimatedVFX _attackVFX;

		public override void Install(IEntity entity)
		{
			entity.AddAttackVFX(_attackVFX);
			entity.AddBehaviour<AttackVFXWeaponBehaviour>();
		}
	}
}