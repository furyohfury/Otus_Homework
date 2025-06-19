using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class DisableAnimatorBehaviour : IEntityInit, IEntityEnable, IEntityDisable
	{
		private Animator _animator;
		private float _cachedSpeed;

		public void Init(IEntity entity)
		{
			_animator = entity.GetAnimator();
			CacheAnimatorSpeed();
		}

		public void Enable(IEntity entity)
		{
			_animator.speed = _cachedSpeed;
		}

		private void CacheAnimatorSpeed()
		{
			_cachedSpeed = _animator.speed != 0
				? _animator.speed
				: 1;
		}

		public void Disable(IEntity entity)
		{
			CacheAnimatorSpeed();
			_animator.speed = 0;
		}
	}
}