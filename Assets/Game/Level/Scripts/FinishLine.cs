using System;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Collider2D))]
	public class FinishLine : MonoBehaviour
	{
		public event Action OnCrossed;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetEntity(out IEntity entity)
			    && entity.HasCharacterTag())
			{
				OnCrossed?.Invoke();
			}
		}
	}
}