using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
	[Serializable]
	public sealed class DeathEventAfterVFXBehaviour : IEntityInit, IEntityDispose
	{
		[SerializeField]
		private AnimatedVFX _vfx;
		[SerializeField]
		private Transform _container;

		private Transform _transform;
		private IEvent _deathRequest;
		private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_transform = entity.GetVisualTransform();
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeath);
			_deathEvent = entity.GetDeathEvent();
		}

		private void OnDeath()
		{
			SpawnVFX();
			_vfx.OnEnded += OnActiveVFXEnded;
		}

		private void OnActiveVFXEnded()
		{
			_vfx.OnEnded -= OnActiveVFXEnded;
			_deathEvent.Invoke();
		}

		private void SpawnVFX()
		{
			_vfx.Show();
		}

		public void Dispose(IEntity entity)
		{
			_vfx.OnEnded -= OnActiveVFXEnded;
			_deathRequest.Unsubscribe(OnDeath);
		}
	}
}