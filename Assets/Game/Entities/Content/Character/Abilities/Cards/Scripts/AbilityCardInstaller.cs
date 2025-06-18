using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
	public sealed class AbilityCardInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private SpriteRenderer[] _spriteRenderer;
		[SerializeField]
		private AbilityCardConfig _abilityCardConfig;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;
		[SerializeField]
		private Transform _transform;

		private IEntity _entity;

		public override void Install(IEntity entity)
		{
			_entity = entity;

			entity.AddAbilityCardTag();
			entity.AddVisualTransform(_transform);
			entity.AddSpriteRenderers(_spriteRenderer);
			_triggerReceiver.OnTriggerEnter += OnTrigger;
			entity.AddAbilityCardConfig(new ReactiveVariable<AbilityCardConfig>(_abilityCardConfig));
		}

		public void SetConfig(AbilityCardConfig abilityCardConfig)
		{
			_abilityCardConfig = abilityCardConfig;
			if (_entity.TryGetAbilityCardConfig(out ReactiveVariable<AbilityCardConfig> config) == false)
			{
				_entity.AddAbilityCardConfig(new ReactiveVariable<AbilityCardConfig>(abilityCardConfig));
			}
			else
			{
				config.Value = abilityCardConfig;
			}

			SetSpriteFromConfig();
		}

		private void OnTrigger(Collider2D other)
		{
			if (!other.TryGetEntity(out var collidedEntity) || !collidedEntity.HasCharacterTag())
			{
				return;
			}

			if (collidedEntity.TryGetAbilityCardPickupEvent(out IEvent<AbilityCardConfig> pickupEvent))
			{
				pickupEvent.Invoke(_abilityCardConfig);
			}

			SceneEntity.Destroy(_entity);
		}

#if UNITY_EDITOR
		[Button]
		private void SetSpriteFromConfig()
		{
			if (_spriteRenderer.Length > 0)
			{
				_spriteRenderer[0].sprite = _abilityCardConfig.Sprite;
			}
		}
#endif
	}
}