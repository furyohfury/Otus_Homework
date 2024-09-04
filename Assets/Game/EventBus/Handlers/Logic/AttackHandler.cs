namespace Lessons.Lesson19_EventBus
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {    
            if (evt.Entity.TryGet(out DamageComponent damageComponent))
            {
                EventBus.RaiseEvent(new DealDamageEvent(evt.Target, damageComponent.Damage));
            }            
        }
    }
}