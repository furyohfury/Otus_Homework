using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentHitPointsComponentObserver
	{
		private readonly ICharacter _hero;

		public EquipmentHitPointsComponentObserver(CharacterEquipment characterEquipment, ICharacter hero)
		{
			_hero = hero;
			characterEquipment.OnEquipped += OnItemEquipped;
			characterEquipment.OnUnequipped += OnItemUnequipped;
		}

		private void OnItemEquipped(EquipmentItem equipmentItem)
		{
			if (equipmentItem.TryGetComponent<EquipmentItem_HealthEffectComponent>(out var component))
			{
				component.Apply();
			}
		}

		private void OnItemUnequipped(EquipmentItem equipmentItem)
		{
			if (equipmentItem.TryGetComponent<EquipmentItem_HealthEffectComponent>(out var component))
			{
				component.Discard();
			}
		}
	}
}