using Entities;

namespace EventBus
{
    public struct VampiricEvent : IEvent
    {
        public Entity Entity;
        public int Damage;
        public float Probability;
        
        public VampiricEvent(Entity entity, int damage, float probability)
        {
            Entity = entity;            
            Damage = damage;
            Probability = probability;
        }
    }
}