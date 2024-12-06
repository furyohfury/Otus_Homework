using System;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class AbilityCard : MonoBehaviour
	{
		[SerializeField]
		private Image _image;
		[SerializeField]
		private AbilityCardConfig _abilityCardConfig;

		private void OnTriggerEnter2D(Collider2D other)
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