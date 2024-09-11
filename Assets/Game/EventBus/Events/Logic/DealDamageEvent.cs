using Entities;

namespace EventBus
{
    public struct DealDamageEvent : IEvent
    {
        public Entity Target;
        public int Damage;
        
        public DealDamageEvent(Entity target, int damage)
        {
            Target = target;
            Damage = damage;
        }
    }
}