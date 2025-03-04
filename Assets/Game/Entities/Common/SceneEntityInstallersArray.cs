using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SceneEntityInstallersArray : SceneEntityInstallerBase
	{
		[SerializeField]
		private SceneEntityInstallerBase[] _installers;

		public override void Install(IEntity entity)
		{
			for (int i = 0, count = _installers.Length; i < count; i++)
			{
				_installers[i].Install(entity);
			}
		}
	}
}