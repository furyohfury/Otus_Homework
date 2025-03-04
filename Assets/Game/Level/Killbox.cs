using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class Killbox : MonoBehaviour
	{
		[SerializeField]
		private Collider2D _collider2D;

		private void Awake()
		{
			_collider2D.isTrigger = true;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetEntity(out var entity)
			    && entity.TryGetHealth(out var health))
			{
				health.Value = 0;
			}
		}
	}
}