﻿using Lessons.Meta.Lesson_Inventory;
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
		// private EquipmentInventoryMediator _equipmentInventoryMediator;

		private void Start()
		{
			_equipmentManaComponentObserver = new EquipmentManaComponentObserver(CharacterEquipment, Hero.Instance);
			_equipmentHitPointsComponentObserver =
				new EquipmentHitPointsComponentObserver(CharacterEquipment, Hero.Instance);
			// _equipmentInventoryMediator = new EquipmentInventoryMediator(CharacterEquipment, Inventory);

			new InventoryHealthComponentObserver(Inventory, Hero.Instance);
			new InventoryManaComponentObserver(Inventory, Hero.Instance);
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
		public void EquipItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item;
			CharacterEquipment.TryEquipItem(item);
		}

		[Button]
		public void UnequipItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item;
			CharacterEquipment.UnequipItem(item);
		}
	}
}