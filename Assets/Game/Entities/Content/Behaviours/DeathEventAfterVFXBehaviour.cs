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
		private AnimatedVFX _vfxPrefab;
		[SerializeField]
		private Transform _container;

		private Transform _transform;
		private IEvent _deathRequest;
		private BaseEvent _deathEvent;
		private AnimatedVFX _activeVFX;

		public void Init(IEntity entity)
		{
			_transform = entity.GetVisualTransform();
			_deathRequest = entity.GetDeathRequest();
			_deathRequest.Subscribe(OnDeath);
			_deathEvent = entity.GetDeathEvent();
		}

		private void OnDeath()
		{
			_activeVFX = SpawnVFX();
			_activeVFX.OnEnded += OnActiveVFXEnded;
		}

		private void OnActiveVFXEnded()
		{
			_activeVFX.OnEnded -= OnActiveVFXEnded;
			_deathEvent.Invoke();
		}

		private AnimatedVFX SpawnVFX()
		{
			return Object.Instantiate(_vfxPrefab, _container);
		}

		public void Dispose(IEntity entity)
		{
			if (_activeVFX != null)
			{
				_activeVFX.OnEnded -= OnActiveVFXEnded;
			}

			_deathRequest.Unsubscribe(OnDeath);
		}
	}
}