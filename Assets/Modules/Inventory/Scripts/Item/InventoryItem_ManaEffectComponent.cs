using System;

namespace Lessons.Meta.Lesson_Inventory
{
	[Serializable]
	public class InventoryItem_ManaEffectComponent : IItemComponent
	{
		public float ManaValue;

		public IItemComponent Clone()
		{
			return new InventoryItem_ManaEffectComponent
			       {
				       ManaValue = ManaValue
			       };
		}
	}
}