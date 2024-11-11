using Lessons.Meta.Lesson_Inventory;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentHitPointsComponentObserver
	{
		private readonly CharacterEquipment _characterEquipment;
		private readonly ICharacter _hero;

		public EquipmentHitPointsComponentObserver(CharacterEquipment characterEquipment, ICharacter hero)
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
			if (item.TryGetComponent<InventoryItem_HealthEffectOnEquipComponent>(out var component))
			{
				_hero.HitPoints += component.HitPoints;
			}
		}

		private void OnItemUnequipped(InventoryItem item)
		{
			if (item.TryGetComponent<InventoryItem_HealthEffectOnEquipComponent>(out var component))
			{
				_hero.HitPoints = Mathf.Max(0, _hero.HitPoints - component.HitPoints);
			}
		}

		public void StopObserving()
		{
			_characterEquipment.OnEquipped -= OnItemEquipped;
			_characterEquipment.OnUnequipped -= OnItemUnequipped;
		}
	}
}