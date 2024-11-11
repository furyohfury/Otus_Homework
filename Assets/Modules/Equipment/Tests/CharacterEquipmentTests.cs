using System.Collections.Generic;
using System.Linq;
using Equipment;
using Lessons.Meta.Lesson_Inventory;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CharacterEquipmentTests
{
	private CharacterEquipment _equipment;

	[SetUp]
	public void SetupTests()
	{
		_equipment = new CharacterEquipment();
	}

	[Test]
	public void WhenAddItemInEquipment_ThenItAppearsThere()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var item = new InventoryItem
		           { Description = "desc", Name = "item", ItemComponents = { equippableSlotComponent } };

		// Act
		_equipment.TryEquipItem(item);
		// Assert
		Assert.Contains(item, _equipment.Items.Values);
	}

	[Test]
	public void WhenAddItemInEquipment_ThenItAppearsOnCorrespondingSlot()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var item = new InventoryItem { ItemComponents = { equippableSlotComponent } };

		// Act
		_equipment.TryEquipItem(item);
		// Assert
		Assert.IsTrue(_equipment.Items[EquipmentSlot.Head] == item);
	}

	[Test]
	public void WhenAddItemToEquipment_AndSlotIsBusy_ThenReturnOldItemInInventory()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var oldItem = new InventoryItem { ItemComponents = { equippableSlotComponent.Clone() } };
		var newItem = new InventoryItem { ItemComponents = { equippableSlotComponent.Clone() } };

		var inventory = new Inventory();
		_equipment.TryEquipItem(oldItem);
		inventory.AddItem(newItem);
		// var equipmentController = new EquipmentInventoryequipmentController(_equipment, inventory);
		// Act
		_equipment.TryEquipItem(newItem);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(oldItem, out _));
	}

	[Test]
	public void WhenEquipItem_ThenItDisappearsFromInventory()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var item = new InventoryItem { ItemComponents = { equippableSlotComponent } };
		var inventory = new Inventory();
		inventory.AddItem(item);
		var equipmentController = new EquipmentController(_equipment, inventory);
		// Act
		equipmentController.TryEquipItemFromInventory(item);
		// Assert
		Assert.IsFalse(inventory.TryFindItem(item, out var _));
	}

	[Test]
	public void WhenEquipItem_AndItHasEquipEffect_ThenIncreaseOwnerStats()
	{
		// Arrange
		var manaComponent = new InventoryItem_ManaEffectOnEquipComponent { ManaValue = 2 };
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var item = new InventoryItem
		           { ItemComponents = new List<IItemComponent> { manaComponent, equippableSlotComponent } };


		var hero = new HeroMock { ManaPoints = 5 };
		var mana = hero.ManaPoints;
		var observer = new EquipmentManaComponentObserver(_equipment, hero);
		observer.StartObserving();
		// Act
		_equipment.TryEquipItem(item);
		// Assert
		Assert.IsTrue(Mathf.Approximately(hero.ManaPoints, mana + 2));
	}

	[Test]
	public void WhenEquipItem_AndItHasEquipEffect_ThenDecreaseOwnerStats()
	{
		// Arrange
		var manaComponent = new InventoryItem_ManaEffectOnEquipComponent { ManaValue = 2 };
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };

		var item = new InventoryItem
		           { ItemComponents = new List<IItemComponent> { manaComponent, equippableSlotComponent } };


		var hero = new HeroMock { ManaPoints = 5 };
		var observer = new EquipmentManaComponentObserver(_equipment, hero);
		observer.StartObserving();
		_equipment.TryEquipItem(item);
		var mana = hero.ManaPoints;
		// Act
		_equipment.UnequipItem(item);
		// Assert
		Assert.IsTrue(Mathf.Approximately(hero.ManaPoints, mana - manaComponent.ManaValue));
	}

	[Test]
	public void WhenEquipItem_And_ItemIsNotEquippable_ThenStaysInInventory()
	{
		// Assert
		var inventoryItem = new InventoryItem();
		var inventory = new Inventory();
		inventory.AddItem(inventoryItem);

		// Act
		_equipment.TryEquipItem(inventoryItem);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(inventoryItem, out _));
		Assert.IsFalse(_equipment.Items.Values.Contains(inventoryItem));
	}

	[Test]
	public void WhenItemIsNotInInventory_AndTryToEquip_ThenCantEquip()
	{
		// Assert
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };

		var item = new InventoryItem
		           { ItemComponents = new List<IItemComponent> { equippableSlotComponent }, Name = "Helm" };
		var inventory = new Inventory();
		var equipmentController = new EquipmentController(_equipment, inventory);
		// Act
		equipmentController.TryEquipItemFromInventory(item);
		// Assert
		Assert.IsFalse(_equipment.Items.Values.Contains(item));
	}

	[Test]
	public void WhenUnequipItem_ThenReturnItToInventory()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };

		var item = new InventoryItem
		           { ItemComponents = new List<IItemComponent> { equippableSlotComponent }, Name = "Helm" };
		var inventory = new Inventory();
		inventory.AddItem(item);
		var equipmentController = new EquipmentController(_equipment, inventory);
		equipmentController.TryEquipItemFromInventory(item);
		// Act
		equipmentController.UnequipItem(item);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(item, out _));
		Assert.IsFalse(_equipment.Items.Values.Contains(item));
	}

	[Test]
	public void WhenEquipSameItem_AndItHasEquipEffect_ThenApplyEffect()
	{
		// Arrange
		var hero = new HeroMock { HitPoints = 2 };
		var oldHitPoints = hero.HitPoints;

		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var hitPointComponent = new InventoryItem_HealthEffectOnEquipComponent { HitPoints = 50 };
		var oldItem = new InventoryItem
		              { ItemComponents = new List<IItemComponent> { equippableSlotComponent }, Name = "Helm" };
		var newItem = new InventoryItem
		              { ItemComponents = new List<IItemComponent> { equippableSlotComponent, hitPointComponent }, Name = "Helm" };
		var inventory = new Inventory();
		inventory.AddItem(oldItem);

		var equipmentController = new EquipmentController(_equipment, inventory);
		var observer = new EquipmentHitPointsComponentObserver(_equipment, hero);
		observer.StartObserving();
		equipmentController.TryEquipItemFromInventory(oldItem);
		inventory.AddItem(newItem);
		// Act
		equipmentController.TryEquipItemFromInventory(newItem);
		// Assert
		Assert.IsTrue(hero.HitPoints == oldHitPoints + 50);
	}

	[Test]
	public void WhenUnequipItem_AndSameItemIsInInventory_ThenUnequipAndSwapItemInInventoryToOld()
	{
		// Arrange
		var equippableSlotComponent = new InventoryItem_EquippableSlotComponent { Slot = EquipmentSlot.Head };
		var hitPointComponent = new InventoryItem_HealthEffectOnEquipComponent { HitPoints = 50 };
		var oldItem = new InventoryItem
		              { ItemComponents = new List<IItemComponent> { equippableSlotComponent, hitPointComponent }, Name = "Helm" };
		var newItem = new InventoryItem
		              { ItemComponents = new List<IItemComponent> { equippableSlotComponent }, Name = "Helm" };
		var inventory = new Inventory();
		inventory.AddItem(oldItem);

		var equipmentController = new EquipmentController(_equipment, inventory);
		equipmentController.TryEquipItemFromInventory(oldItem);
		inventory.AddItem(newItem);
		// Act
		equipmentController.UnequipItem(oldItem);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(oldItem, out var inventoryItem));
		Assert.IsTrue(inventoryItem.TryGetComponent(out InventoryItem_HealthEffectOnEquipComponent _));
	}
}