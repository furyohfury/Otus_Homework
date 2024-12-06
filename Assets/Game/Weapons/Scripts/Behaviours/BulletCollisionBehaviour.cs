using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class BulletCollisionBehaviour : IEntityInit, IEntityDispose
	{
		private IValue<int> _damage;
		private TriggerReceiver _triggerReceiver;
        private BaseEvent _deathEvent;

		public void Init(IEntity entity)
		{
			_damage = entity.GetDamage();
            _deathEvent = entity.GetDeathEvent();
			_triggerReceiver = entity.GetTriggerReceiver();
			_triggerReceiver.OnTriggerEnter += OnTriggerEntered;
		}

		private void OnTriggerEntered(Collider2D collider)
		{
			if (collider.TryGetEntity(out var entity)
             && entity.HasHealth()
            && entity.TryGetTakeDamageRequest(out var request))
			{
				request.Invoke(_damage.Value);
			}

			_deathEvent.Invoke();
		}

		public void Dispose(IEntity entity)
		{
			_triggerReceiver.OnTriggerEnter -= OnTriggerEntered;
		}
	}
}