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
		private EquipmentController _equipmentController;
		private InventoryHealthComponentObserver _inventoryHealthComponentObserver;
		private InventoryManaComponentObserver _inventoryManaComponentObserver;

		private void Start()
		{
			_equipmentManaComponentObserver = new EquipmentManaComponentObserver(CharacterEquipment, Hero.Instance);
			_equipmentHitPointsComponentObserver =
				new EquipmentHitPointsComponentObserver(CharacterEquipment, Hero.Instance);
			_equipmentManaComponentObserver.StartObserving();
			_equipmentHitPointsComponentObserver.StartObserving();


			_inventoryHealthComponentObserver = new InventoryHealthComponentObserver(Inventory, Hero.Instance);
			_inventoryManaComponentObserver = new InventoryManaComponentObserver(Inventory, Hero.Instance);
			_inventoryManaComponentObserver.StartObserving();
			_inventoryHealthComponentObserver.StartObserving();

			_equipmentController = new EquipmentController(CharacterEquipment, Inventory);
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
			var item = itemConfig.Item.Clone();
			_equipmentController.TryEquipItemFromInventory(item);
		}

		[Button]
		public void UnequipItem(InventoryItemConfig itemConfig)
		{
			var item = itemConfig.Item.Clone();
			_equipmentController.UnequipItem(item);
		}

		private void OnDestroy()
		{
			_equipmentManaComponentObserver.StopObserving();
			_equipmentHitPointsComponentObserver.StopObserving();
			_inventoryHealthComponentObserver.StopObserving();
			_inventoryManaComponentObserver.StopObserving();
		}
	}
}