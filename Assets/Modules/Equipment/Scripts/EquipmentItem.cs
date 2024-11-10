// using System;
// using Lessons.Meta.Lesson_Inventory;
//
// namespace Equipment
// {
// 	[Serializable]
// 	public sealed class InventoryItem : InventoryItem
// 	{
// 		public EquipmentSlot Slot;
//
// 		public new InventoryItem Clone()
// 		{
// 			return new InventoryItem
// 			       {
// 				       Description = Description,
// 				       Flags = Flags,
// 				       Icon = Icon,
// 				       ItemComponents = CloneComponents(),
// 				       Name = Name,
// 				       Slot = Slot
// 			       };
// 		}
// 	}
// }