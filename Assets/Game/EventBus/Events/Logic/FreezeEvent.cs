namespace EventBus
{   
    public struct FreezeEvent : IEvent
    {
        private Entity Target;

        public FreezeEvent(Entity target)
        {
            Target = target;
        }
    }
}