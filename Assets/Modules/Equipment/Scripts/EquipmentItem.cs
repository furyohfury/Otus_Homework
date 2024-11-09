using System;
using Lessons.Meta.Lesson_Inventory;

namespace Equipment
{
	[Serializable]
	public sealed class EquipmentItem : InventoryItem
	{
		public EquipmentSlot Slot;

		public new EquipmentItem Clone()
		{
			return new EquipmentItem
			       {
				       Description = Description,
				       Flags = Flags,
				       Icon = Icon,
				       ItemComponents = CloneComponents(),
				       Name = Name,
				       Slot = Slot
			       };
		}
	}
}