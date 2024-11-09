using System;
using System.Collections.Generic;
using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	[Serializable]
	public sealed class CharacterEquipment
	{
		public Action<EquipmentItem> OnEquipped;
		public Action<EquipmentItem> OnUnequipped;

		[SerializeReference]
		public Dictionary<EquipmentSlot, EquipmentItem> Items = new();

		public bool TryEquipItem(InventoryItem item)
		{
			if (item is not EquipmentItem equipmentItem)
			{
				return false;
			}

			var slot = equipmentItem.Slot;
			if (Items.TryGetValue(slot, out var oldItem))
			{
				SwapItems(oldItem, equipmentItem);
			}
			else
			{
				Items.Add(slot, equipmentItem);
				OnEquipped?.Invoke(equipmentItem);
			}

			return true;
		}

		public void UnequipItem(EquipmentItem equipmentItem)
		{
			if (Items.TryGetValue(equipmentItem.Slot, out var equippedItem) == false 
			    || IsSameItem(equipmentItem, equippedItem) == false)
			{
				Debug.Log($"No {equipmentItem.Name} in equipment to discard");
				return;
			}

			Items.Remove(equipmentItem.Slot);
			OnUnequipped?.Invoke(equipmentItem);
		}

		private void SwapItems(EquipmentItem oldItem, EquipmentItem newItem)
		{
			Items[oldItem.Slot] = newItem;
			OnEquipped?.Invoke(newItem);
			OnUnequipped?.Invoke(oldItem);
		}

		private bool IsSameItem(EquipmentItem initial, EquipmentItem other)
		{
			return initial.Name == other.Name;
		}
	}
}