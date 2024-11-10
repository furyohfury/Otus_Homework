using System;
using System.Collections.Generic;
using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	[Serializable]
	public sealed class CharacterEquipment
	{
		public event Action<InventoryItem> OnEquipped;
		public event Action<InventoryItem> OnUnequipped;

		[SerializeReference]
		public Dictionary<EquipmentSlot, InventoryItem> Items = new();

		public bool TryEquipItem(InventoryItem item)
		{
			if (item.TryGetComponent(out InventoryItem_EquippableSlotComponent slotComponent) == false)
			{
				Debug.Log($"Cant equip {item.Name}. It isn't equippable");
				return false;
			}
			
			var slot = slotComponent.Slot;
			if (Items.TryGetValue(slot, out InventoryItem oldItem))
			{
				SwapItems(oldItem, item, slot);
			}
			else
			{
				Items.Add(slot, item );
				OnEquipped?.Invoke(item);
			}
			return true;
		}

		public void UnequipItem(InventoryItem item)
		{
			if (item.TryGetComponent(out InventoryItem_EquippableSlotComponent slotComponent) == false)
			{
				Debug.Log($"Cant unequip {item.Name}. It isn't equippable");
				return;
			}
			
			if (Items.TryGetValue(slotComponent.Slot, out var equippedItem) == false 
			    || IsSameItem(item, equippedItem) == false)
			{
				Debug.Log($"No {item.Name} in equipment to discard");
				return;
			}

			Items.Remove(slotComponent.Slot);
			OnUnequipped?.Invoke(item);
		}

		private void SwapItems(InventoryItem oldItem, InventoryItem newItem, EquipmentSlot slot)
		{
			Items[slot] = newItem;
			OnEquipped?.Invoke(newItem);
			OnUnequipped?.Invoke(oldItem);
		}

		private bool IsSameItem(InventoryItem initial, InventoryItem other)
		{
			return initial.Name == other.Name;
		}
	}
}