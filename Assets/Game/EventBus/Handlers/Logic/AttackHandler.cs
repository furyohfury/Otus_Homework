namespace Lessons.Lesson19_EventBus
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {    
            if (evt.Source.TryGetData(out DamageComponent sourcedamageComponent))
            {
                EventBus.RaiseEvent(new DealDamageEvent(evt.Target, sourceDamageComponent.Damage));
            }            
            if (evt.Target.TryGetData(out DamageComponent targetDamageComponent))
            {
                EventBus.RaiseEvent(new DealDamageEvent(evt.Source, targetDamageComponent.Damage));
            }
        }
    }
}