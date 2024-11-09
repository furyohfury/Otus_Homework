using System;

namespace Lessons.Meta.Lesson_Inventory
{
	[Serializable]
	public class InventoryItem_HealthEffectComponent : IItemComponent, IEffectibleComponent
	{
		public int HitPoints = 2;

		public IItemComponent Clone()
		{
			return new InventoryItem_HealthEffectComponent
			       {
				       HitPoints = HitPoints
			       };
		}

		public void Apply()
		{
			Hero.Instance.HitPoints += HitPoints;
		}

		public void Discard()
		{
			Hero.Instance.HitPoints -= HitPoints;
		}
	}
	
}