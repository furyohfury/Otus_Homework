using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DeathStopAnimatorBehaviour : IEntityInit, IEntityDispose
	{
		private IEvent _deathRequest;
		private Animator _animator;

		public void Init(IEntity entity)
		{
			_animator = entity.GetAnimator();
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeathRequest);
		}

		private void OnDeathRequest()
		{
			_animator.speed = 0;
		}

		public void Dispose(IEntity entity)
		{
			_deathRequest.Unsubscribe(OnDeathRequest);
		}
	}
}