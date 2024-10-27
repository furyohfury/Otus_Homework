using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
	[Serializable]
	public sealed class ResourceStorageComponent : MonoBehaviour
	{
		public event Action OnStateChanged;

		public int Current => current;
		public int FreeSlots => capacity - current;

		[SerializeField]
		private int capacity;

		[SerializeField]
		private int current;

		public bool CanAddResources(int range)
		{
			return current + range <= capacity;
		}

		[Button]
		public void AddResources(int range)
		{
			current = Mathf.Min(capacity, current + range);
			OnStateChanged?.Invoke();
		}

		[Button]
		public bool RemoveResources(int count)
		{
			if (current - count >= 0)
			{
				current -= count;
				OnStateChanged?.Invoke();
				return true;
			}

			return false;
		}

		[Button]
		public int ExtractAllResources()
		{
			var result = current;
			current = 0;
			OnStateChanged?.Invoke();
			return result;
		}

		[Button]
		public void Clear()
		{
			current = 0;
			OnStateChanged?.Invoke();
		}

		public bool IsFull()
		{
			return current == capacity;
		}

		public bool IsNotFull()
		{
			return current < capacity;
		}

		public bool IsNotEmpty()
		{
			return current > 0;
		}

		public bool IsEmpty()
		{
			return current == 0;
		}
	}
}