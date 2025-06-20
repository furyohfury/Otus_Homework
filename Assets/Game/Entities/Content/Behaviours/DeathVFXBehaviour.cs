using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DeathVFXBehaviour : IEntityInit, IEntityDispose
	{
		[SerializeField]
		private GameObject _vfx;
		
		public void Init(IEntity entity)
		{
			if (entity.TryGetDeathEvent(out var deathEvent))
			{
				deathEvent.Subscribe(OnDeath);
			}
		}

		private void OnDeath()
		{
			
		}

		public void Dispose(IEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}