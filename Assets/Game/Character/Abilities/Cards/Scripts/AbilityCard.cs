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
			if (other.TryGetEntity(out var entity) && entity.HasCharacterTag())
			{
				ApplyAspect(entity);
				Destroy(gameObject);
			}
		}

		private void ApplyAspect(IEntity entity)
		{
			entity.ApplyAspect(_aspect);
		}
	}
}