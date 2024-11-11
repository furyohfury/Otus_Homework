using System;
using Lessons.Meta.Lesson_Inventory;

namespace Equipment
{
	[Serializable]
	public class InventoryItem_HealthEffectOnEquipComponent : IItemComponent
	{
		public int HitPoints = 2;

		public IItemComponent Clone()
		{
			return new InventoryItem_HealthEffectOnEquipComponent
			       {
				       HitPoints = HitPoints
			       };
		}
	}
}