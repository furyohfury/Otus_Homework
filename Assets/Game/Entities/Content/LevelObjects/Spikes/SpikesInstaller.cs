using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class SpikesInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private string _id = "Spikes";
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField] 
		private Transform _transform;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private float _damageCooldown;

		private IEntity _entity;
		private readonly HashSet<IEntity> _damagedEntities = new();


		public override void Install(IEntity entity)
		{
			_entity = entity;
			entity.AddTag(TagAPI.LevelEntity);
			entity.AddId(_id);
			entity.AddVisualTransform(_transform);
			_triggerReceiver.OnTriggerStay += OnCollided;
		}

		private void OnCollided(Collider2D collider)
		{
			if (collider.isTrigger
			    || collider.TryGetEntity(out var collidedEntity) == false
			    || collidedEntity.TryGetTakeDamageRequest(out BaseEvent<int> takeDamageRequest) == false
			    || _damagedEntities.Contains(collidedEntity))
			{
				return;
			}

			takeDamageRequest.Invoke(_damage);
			_damagedEntities.Add(collidedEntity);
			var timer = new Timer(_damageCooldown);
			timer.OnEnded += () => OnDamageCooldownPassed(collidedEntity);
			_entity.WhenUpdate(timer.Tick);
			timer.Start();
		}

		private void OnDamageCooldownPassed(IEntity collidedEntity)
		{
			_damagedEntities.Remove(collidedEntity);
		}
	}
}