using System;
using Lessons.Meta.Lesson_Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Equipment
{
	public sealed class EquipmentDebug : MonoBehaviour
	{
		public CharacterEquipment CharacterEquipment;
		public Inventory Inventory;

		private EquipmentManaComponentObserver _equipmentManaComponentObserver;
		private EquipmentHitPointsComponentObserver _equipmentHitPointsComponentObserver;
		private EquipmentInventoryMediator _equipmentInventoryMediator;
		private InventoryHealthComponentObserver _healthComponentObserver;
		private InventoryManaComponentObserver _manaComponentObserver;

		private void Start()
		{
			_equipmentManaComponentObserver = new EquipmentManaComponentObserver(CharacterEquipment, Hero.Instance);
			_equipmentHitPointsComponentObserver = new EquipmentHitPointsComponentObserver(CharacterEquipment, Hero.Instance);
			_equipmentInventoryMediator = new(CharacterEquipment, Inventory);
			
			_healthComponentObserver = new InventoryHealthComponentObserver(Inventory, Hero.Instance);
			_manaComponentObserver = new InventoryManaComponentObserver(Inventory, Hero.Instance);
		}
		
		[Button]
		public void AddItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item.Clone();
			Inventory.AddItem(item);
		}

		[Button]
		public void RemoveItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item.Clone();
			Inventory.RemoveItem(item);
		}

		[Button]
		public void ConsumeItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item.Clone();
			Inventory.ConsumeItem(item);
		}

		[Button]
		public void EquipItem(EquipmentItemConfig itemConfig)
		{
			var item = itemConfig.CreateEquipmentItem();
			CharacterEquipment.TryEquipItem(item);
		}
		
		[Button]
		public void UnequipItem(EquipmentItemConfig itemConfig)
		{
			var item = itemConfig.CreateEquipmentItem();
			CharacterEquipment.UnequipItem(item);
		}
	}
}