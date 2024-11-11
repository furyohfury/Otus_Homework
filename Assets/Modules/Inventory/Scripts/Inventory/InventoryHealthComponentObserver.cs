namespace Lessons.Meta.Lesson_Inventory
{
    public class InventoryHealthComponentObserver
    {
        private readonly Inventory _inventory;
        private readonly Hero _hero;

        public InventoryHealthComponentObserver(Inventory inventory, Hero hero)
        {
            _inventory = inventory;
            _hero = hero;
        }
        
        public void StartObserving()
        {
            _inventory.OnAdded += InventoryOnOnAdded;
            _inventory.OnRemoved += InventoryOnOnRemoved;
        }

        private void InventoryOnOnAdded(InventoryItem inventoryItem)
        {
            if ((inventoryItem.Flags & ItemFlags.Effectible) == ItemFlags.Effectible)
            {
                if (inventoryItem.TryGetComponent<InventoryItem_HealthEffectComponent>(out var component))
                {
                    _hero.HitPoints += component.HitPoints;
                }   
            }
        }

        private void InventoryOnOnRemoved(InventoryItem inventoryItem)
        {
            if ((inventoryItem.Flags & ItemFlags.Effectible) == ItemFlags.Effectible)
            {
                if (inventoryItem.TryGetComponent<InventoryItem_HealthEffectComponent>(out var component))
                {
                    _hero.HitPoints -= component.HitPoints;
                }   
            }
        }
        
        public void StopObserving()
        {
            _inventory.OnAdded -= InventoryOnOnAdded;
            _inventory.OnRemoved -= InventoryOnOnRemoved;
        }
    }
}