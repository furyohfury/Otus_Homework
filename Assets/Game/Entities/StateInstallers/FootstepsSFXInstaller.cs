using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class FootstepsSFXInstaller : IEntityInstaller
	{
		[SerializeField]
		private AudioClip[] _sfxs;

		public void Install(IEntity entity)
		{
			entity.AddFootstepsSounds(_sfxs);
		}
	}
}