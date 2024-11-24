using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class WeaponCollisionBehaviour : IEntityInit, IEntityDispose
	{
		private IValue<int> _damage;
		private TriggerReceiver _triggerReceiver;

		public void Init(IEntity entity)
		{
			_damage = entity.GetDamage();
			_triggerReceiver = entity.GetTriggerReceiver();
			_triggerReceiver.OnTriggerEnter += OnTriggerEntered;
		}

		private void OnTriggerEntered(Collider2D collider)
		{
			if (!collider.TryGetEntity(out var entity))
			{
				return;
			}

			if (!entity.TryGetHealth(out var health))
			{
				return;
			}

			health.Value -= _damage.Value;
		}

		public void Dispose(IEntity entity)
		{
			_triggerReceiver.OnTriggerEnter -= OnTriggerEntered;
		}
	}
}