using Lessons.Meta.Lesson_Inventory;

namespace Equipment
{
	public sealed class EquipmentInventoryMediator
	{
		private readonly Inventory _inventory;

		public EquipmentInventoryMediator(CharacterEquipment characterEquipment, Inventory inventory)
		{
			_inventory = inventory;
			characterEquipment.OnEquipped += OnItemEquipped;
			characterEquipment.OnUnequipped += OnItemUnequipped;
		}

		private void OnItemEquipped(EquipmentItem item)
		{
			_inventory.RemoveItem(item);
		}

		private void OnItemUnequipped(EquipmentItem item)
		{
			_inventory.AddItem(item);
		}
	}
}