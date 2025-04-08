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
			if (other.TryGetEntity(out var entity) == false)
			{
				return;
			}
			if (entity.TryGetHealth(out var health))
			{
				health.Value = 0;
			}
			else if (entity.TryGetDeathRequest(out var request))
			{
				request.Invoke();
			}
		}
	}
}