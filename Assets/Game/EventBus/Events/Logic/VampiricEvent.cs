using Entities;

namespace EventBus
{
    public struct VampiricEvent : IEvent
    {
        public Entity Entity;
        public int Damage;
        public int Probability;
        
        public VampiricEvent(Entity entity, int damage, int probability)
        {
            Entity = entity;            
            Damage = damage;
            Probability = probability;
        }
    }
}