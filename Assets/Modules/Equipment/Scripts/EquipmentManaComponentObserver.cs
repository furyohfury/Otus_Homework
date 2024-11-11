using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentManaComponentObserver
	{
		private readonly ICharacter _hero;
		private readonly CharacterEquipment _characterEquipment;

		public EquipmentManaComponentObserver(CharacterEquipment characterEquipment, ICharacter hero)
		{
			_characterEquipment = characterEquipment;
			_hero = hero;
		}

		public void StartObserving()
		{
			_characterEquipment.OnEquipped += OnItemEquipped;
			_characterEquipment.OnUnequipped += OnItemUnequipped;
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
		
		public void StopObserving()
		{
			_characterEquipment.OnEquipped -= OnItemEquipped;
			_characterEquipment.OnUnequipped -= OnItemUnequipped;
		}
	}
}