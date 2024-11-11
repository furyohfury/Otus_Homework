using System;
using Lessons.Meta.Lesson_Inventory;

namespace Equipment
{
	[Serializable]
	public class InventoryItem_ManaEffectOnEquipComponent : IItemComponent
	{
		public int ManaValue = 2;

		public IItemComponent Clone()
		{
			return new InventoryItem_ManaEffectOnEquipComponent
			       {
				       ManaValue = ManaValue
			       };
		}
	}
}