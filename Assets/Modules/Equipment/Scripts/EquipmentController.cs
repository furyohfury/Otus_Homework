using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentController
	{
		private readonly Inventory _inventory;
		private readonly CharacterEquipment _equipment;

		public EquipmentController(CharacterEquipment characterEquipment, Inventory inventory)
		{
			_equipment = characterEquipment;
			_inventory = inventory;
			characterEquipment.OnEquipped += OnItemEquipped;
			characterEquipment.OnUnequipped += OnItemUnequipped;
		}

		public bool TryEquipItemFromInventory(InventoryItem item)
		{
			if (_inventory.TryFindItem(item, out var inventoryItem) == false)
			{
				Debug.Log($"Can't equip {item.Name} because it isn't in inventory");
				return false;
			}

			return _equipment.TryEquipItem(inventoryItem);
		}

		public void UnequipItem(InventoryItem item)
		{
			if (_inventory.TryFindItem(item, out var inventoryItem))
			{
				_inventory.RemoveItem(inventoryItem);
			}

			_equipment.UnequipItem(item);
		}

		private void OnItemEquipped(InventoryItem item)
		{
			_inventory.RemoveItem(item);
		}

		private void OnItemUnequipped(InventoryItem item)
		{
			_inventory.AddItem(item);
		}
	}
}