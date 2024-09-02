namespace Lessons.Lesson19_EventBus
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {
            
            
            if (evt.Entity.TryGet(out StatsComponent stats))
            {
                EventBus.RaiseEvent(new DealDamageEvent(evt.Target, stats.Strength));
            }
            
            if (evt.Entity.TryGet(out WeaponComponent weaponComponent))
            {
                var weapon = weaponComponent.Weapon;
                var effects = weapon.Effects;
                
                foreach (var effect in effects)
                {
                    effect.Source = evt.Entity;
                    effect.Target = evt.Target;
                    
                    EventBus.RaiseEvent(effect);
                }
            }
        }
    }
}