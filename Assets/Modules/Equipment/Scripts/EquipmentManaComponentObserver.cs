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

		private void OnItemEquipped(InventoryItem item)
		{
			if (item.TryGetComponent<InventoryItem_ManaEffectOnEquipComponent>(out var component))
			{
				_hero.ManaPoints += component.ManaValue;
			}
		}

		private void OnItemUnequipped(InventoryItem item)
		{
			if (item.TryGetComponent<InventoryItem_ManaEffectOnEquipComponent>(out var component))
			{
				_hero.ManaPoints = Mathf.Max(0, _hero.ManaPoints - component.ManaValue);
			}
		}
	}
}