using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentManaComponentObserver
	{
		private readonly ICharacter _hero;

		public EquipmentManaComponentObserver(CharacterEquipment characterEquipment, ICharacter hero)
		{
			_hero = hero;
			characterEquipment.OnEquipped += OnItemEquipped;
			characterEquipment.OnUnequipped += OnItemUnequipped;
		}

		private void OnItemEquipped(EquipmentItem equipmentItem)
		{
			if (equipmentItem.TryGetComponent<InventoryItem_ManaEffectComponent>(out var component))
			{
				_hero.ManaPoints += component.ManaValue;
			}
		}

		private void OnItemUnequipped(EquipmentItem equipmentItem)
		{
			if (equipmentItem.TryGetComponent<InventoryItem_ManaEffectComponent>(out var component))
			{
				_hero.ManaPoints = Mathf.Max(0, _hero.ManaPoints - component.ManaValue);
			}
		}
	}
}