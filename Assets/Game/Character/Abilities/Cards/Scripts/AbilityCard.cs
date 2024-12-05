using Atomic.Entities;
using UnityEngine;

namespace Game
{
	public sealed class AbilityCard : MonoBehaviour
	{
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