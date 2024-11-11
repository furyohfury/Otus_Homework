namespace Lessons.Meta.Lesson_Inventory
{
    public class InventoryManaComponentObserver
    {
        private readonly Inventory _inventory;
        private readonly Hero _hero;

        public InventoryManaComponentObserver(Inventory inventory, Hero hero)
        {
            _inventory = inventory;
            _hero = hero;
        }
        
        public void StartObserving()
        {
            _inventory.OnAdded += InventoryOnOnConsumed;
            _inventory.OnRemoved += InventoryOnOnConsumed;
        }

        private void InventoryOnOnConsumed(InventoryItem inventoryItem)
        {
            if (inventoryItem.TryGetComponent<InventoryItem_ManaEffectComponent>(out var component))
            {
                _hero.ManaPoints += component.ManaValue;
            }   
        }
        
        public void StopObserving()
        {
            _inventory.OnAdded -= InventoryOnOnConsumed;
            _inventory.OnRemoved -= InventoryOnOnConsumed;
        }
    }
}