using System;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public sealed class AbilityCard : SceneEntityInstallerBase
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
		}

		private void OnTrigger(Collider2D other)
		{
			if (!other.TryGetEntity(out var entity) || !entity.HasCharacterTag())
			{
				return;
			}

			if (entity.TryGetApplyAbilityAspectRequest(out var request))
			{
				request.Invoke(_abilityCardConfig.Aspect);
			}

			Destroy(gameObject);
		}
	}
}