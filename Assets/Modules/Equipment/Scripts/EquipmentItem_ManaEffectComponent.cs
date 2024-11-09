using System;
using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	[Serializable]
	public class EquipmentItem_ManaEffectComponent : IItemComponent, IEffectibleComponent
	{
		public int ManaValue = 2;

		public IItemComponent Clone()
		{
			return new EquipmentItem_ManaEffectComponent
			       {
				       ManaValue = ManaValue
			       };
		}

		public void Apply()
		{
			Hero.Instance.ManaPoints += ManaValue;
		}

		public void Discard()
		{
			Hero.Instance.ManaPoints -= Mathf.Max(0, Hero.Instance.ManaPoints - ManaValue);
			;
		}
	}
}