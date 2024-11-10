using Lessons.Meta.Lesson_Inventory;

namespace Equipment
{
	public sealed class InventoryItem_EquippableSlotComponent : IItemComponent
	{
		public EquipmentSlot Slot;

		public IItemComponent Clone()
		{
			return new InventoryItem_EquippableSlotComponent { Slot = Slot };
		}
	}
}