using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public sealed class AbilityCardInstaller : SceneEntityInstallerBase
	{
		[SerializeField]
		private SpriteRenderer _renderer;
		[SerializeField]
		private AbilityCardConfig _abilityCardConfig;
		[SerializeField]
		private TriggerReceiver _triggerReceiver;

		public override void Install(IEntity entity)
		{
			_triggerReceiver.OnTriggerEnter += OnTrigger;
			entity.AddAbilityCardConfig(new ReactiveVariable<AbilityCardConfig>(_abilityCardConfig));
		}

		private void OnTrigger(Collider2D other)
		{
			if (!other.TryGetEntity(out var entity) || !entity.HasCharacterTag())
			{
				return;
			}

			if (entity.TryGetAbilityCardPickupEvent(out BaseEvent<AbilityCardConfig> pickupEvent))
			{
				pickupEvent.Invoke(_abilityCardConfig);
			}

			gameObject.SetActive(false);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_renderer != null && _abilityCardConfig != null)
			{
				_renderer.sprite = _abilityCardConfig.Sprite;
			}
		}
#endif
	}
}