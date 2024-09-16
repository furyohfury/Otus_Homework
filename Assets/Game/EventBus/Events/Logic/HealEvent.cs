using Entities;

namespace EventBus
{
    public struct HealEvent : IEvent
    {
        public Entity Target;
        public int Amount;
        
        public HealEvent(Entity target, int amount)
        {
            Target = target;            
            Amount = amount;
        }
    }
}