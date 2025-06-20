using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class DisablePhysicsOnDeathRequestBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathRequest;
		private Rigidbody2D _rigidbody2D;

		public void Init(IEntity entity)
		{
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
			_rigidbody2D = entity.GetRigidbody2D();
		}

		private void OnDeathRequest()
		{
			_rigidbody2D.simulated = false;
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}