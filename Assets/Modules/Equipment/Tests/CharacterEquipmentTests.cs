using System;
using System.Collections.Generic;
using Equipment;
using Lessons.Meta.Lesson_Inventory;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class CharacterEquipmentTests
{
	[Test]
	public void WhenAddItemInEquipmentItAppearsThere()
	{
		// Arrange
		var item = new EquipmentItem { Description = "desc", Name = "item" };
		var equipment = new CharacterEquipment();
		// Act
		equipment.TryEquipItem(item);
		// Assert
		Assert.Contains(item, equipment.Items.Values);
	}

	[Test]
	public void WhenAddItemInEquipmentItAppearsOnCorrespondingSlot()
	{
		// Arrange
		var equipmentItem = new EquipmentItem { Slot = EquipmentSlot.Head };
		var equipment = new CharacterEquipment();
		// Act
		equipment.TryEquipItem(equipmentItem);
		// Assert
		Assert.IsTrue(equipment.Items[EquipmentSlot.Head] == equipmentItem);
	}

	[Test]
	public void IfThereWasAnItemOnEquipmentSlotThenReturnOldItemToInventory()
	{
		// Arrange
		var oldItem = new EquipmentItem
		                    { Slot = EquipmentSlot.Head };
		var newItem = new EquipmentItem
		              { Slot = EquipmentSlot.Head };
		var equipment = new CharacterEquipment();
		var inventory = new Inventory();
		equipment.TryEquipItem(oldItem);
		inventory.AddItem(newItem);
		var mediator = new EquipmentInventoryMediator(equipment, inventory);
		// Act
		equipment.TryEquipItem(newItem);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(oldItem, out var _));
	}

	[Test]
	public void WhenEquipItemItDisappearsFromInventory()
	{
		// Arrange
		var equipmentItem = new EquipmentItem
		                    { Slot = EquipmentSlot.Head };
		var equipment = new CharacterEquipment();

		var inventory = new Inventory();
		inventory.AddItem(equipmentItem);
		var mediator = new EquipmentInventoryMediator(equipment, inventory);
		// Act
		equipment.TryEquipItem(equipmentItem);
		// Assert
		Assert.IsFalse(inventory.TryFindItem(equipmentItem, out var item));
	}

	[Test]
	public void WhenEquippedIncreaseOwnerStats()
	{
		// Arrange
		var manaComponent = new InventoryItem_ManaEffectComponent { ManaValue = 2 };

		var equipmentItem = new EquipmentItem
		                    { Slot = EquipmentSlot.Head, ItemComponents = new List<IItemComponent> { manaComponent } };
		var equipment = new CharacterEquipment();

		var hero = new HeroMock { ManaPoints = 5 };
		var mana = hero.ManaPoints;
		var observer = new EquipmentManaComponentObserver(equipment, hero);
		// Act
		equipment.TryEquipItem(equipmentItem);
		// Assert
		Assert.IsTrue(Mathf.Approximately(hero.ManaPoints, mana + 2));
	}

	[Test]
	public void WhenUnequippedDecreaseOwnerStats()
	{
		// Arrange
		var manaComponent = new InventoryItem_ManaEffectComponent { ManaValue = 2 };

		var equipmentItem = new EquipmentItem
		                    { Slot = EquipmentSlot.Head, ItemComponents = new List<IItemComponent> { manaComponent } };
		var equipment = new CharacterEquipment();


		var hero = new HeroMock { ManaPoints = 5 };
		var mana = hero.ManaPoints;
		var observer = new EquipmentManaComponentObserver(equipment, hero);
		// Act
		equipment.TryEquipItem(equipmentItem);
		equipment.UnequipItem(equipmentItem);
		// Assert
		Assert.IsTrue(Mathf.Approximately(hero.ManaPoints, mana));
	}

	[Test]
	public void IfItemIsNotEquippableThenDoesntAddInEquipmentAndStaysInInventory()
	{
		// Assert
		var inventoryItem = new InventoryItem();
		var inventory = new Inventory();
		inventory.AddItem(inventoryItem);
		var equipment = new CharacterEquipment();
		// Act
		equipment.TryEquipItem(inventoryItem);
		// Assert
		Assert.IsTrue(inventory.TryFindItem(inventoryItem, out var _));
		Assert.IsFalse(equipment.TryEquipItem(inventoryItem));
	}
}

	