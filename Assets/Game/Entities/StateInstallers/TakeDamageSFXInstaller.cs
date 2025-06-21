using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class TakeDamageSFXInstaller : IEntityInstaller
	{
		[SerializeField]
		private AudioClip[] _sfxs;

		public void Install(IEntity entity)
		{
			entity.AddTakeDamageSounds(_sfxs);
		}
	}
}