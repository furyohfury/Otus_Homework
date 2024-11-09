using System;
using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	[Serializable]
	public class EquipmentItem_HealthEffectComponent : IItemComponent, IEffectibleComponent
	{
		public int HitPoints = 2;

		public IItemComponent Clone()
		{
			return new EquipmentItem_HealthEffectComponent
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
			Hero.Instance.HitPoints = Mathf.Max(0, Hero.Instance.HitPoints - HitPoints);
		}
	}
}