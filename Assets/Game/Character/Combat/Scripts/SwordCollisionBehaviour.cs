using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SwordCollisionBehaviour : IEntityInit, IEntityDispose
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
			if (!collider.TryGetEntity(out var entity) || !entity.HasHealth())
			{
				return;
			}

			if (entity.TryGetTakeDamageRequest(out var request))
			{
				request.Invoke(_damage.Value);
			}
		}

		public void Dispose(IEntity entity)
		{
			_triggerReceiver.OnTriggerEnter -= OnTriggerEntered;
		}
	}
}