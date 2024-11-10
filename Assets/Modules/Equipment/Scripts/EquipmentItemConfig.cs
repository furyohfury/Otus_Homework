// using Lessons.Meta.Lesson_Inventory;
// using UnityEngine;
//
// namespace Equipment
// {
// 	[CreateAssetMenu(fileName = "InventoryItemConfig", menuName = "Equipment/New Equipment Config")]
// 	public sealed class InventoryItemConfig : InventoryItemConfig
// 	{
// 		public InventoryItem CreateInventoryItem()
// 		{
// 			return new InventoryItem
// 			       {
// 				       Description = Item.Description,
// 				       Flags = Item.Flags,
// 				       Icon = Item.Icon,
// 				       ItemComponents = Item.ItemComponents,
// 				       Name = Item.Name,
// 				       Slot = Slot
// 			       };
// 		}
//
// 		public EquipmentSlot Slot;
// 	}
// }