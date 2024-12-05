using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace Game
{
	public class AbilityCard : MonoBehaviour
	{
		[SerializeReference]
		private IEntityAspect _aspect;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.TryGetEntity(out var entity) || !entity.HasCharacterTag())
			{
				return;
			}

			if (entity.TryGetApplyAbilityAspectRequest(out var request))
			{
				request.Invoke(_aspect);
			}
			Destroy(gameObject);
		}
	}
}