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
			if (equipmentItem.TryGetComponent<InventoryItem_HealthEffectComponent>(out var component))
			{
				_hero.HitPoints += component.HitPoints;
			}
		}

		private void OnItemUnequipped(EquipmentItem equipmentItem)
		{
			if (equipmentItem.TryGetComponent<InventoryItem_HealthEffectComponent>(out var component))
			{
				_hero.HitPoints = Mathf.Max(0, _hero.HitPoints - component.HitPoints);
			}
		}
	}
}