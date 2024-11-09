using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	[CreateAssetMenu(fileName = "EquipmentItemConfig", menuName = "Equipment/New Equipment Config")]
	public sealed class EquipmentItemConfig : InventoryItemConfig
	{
		public EquipmentItem CreateEquipmentItem()
		{
			return new EquipmentItem
			{
				Description = Item.Description,
				Flags = Item.Flags,
				Icon = Item.Icon,
				ItemComponents = Item.ItemComponents,
				Name = Item.Name,
				Slot = Slot
			};
		}
		
		[SerializeField]
		private EquipmentSlot Slot;
	}
}