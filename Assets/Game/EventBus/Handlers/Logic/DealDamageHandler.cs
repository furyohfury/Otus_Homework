 namespace Lessons.Lesson19_EventBus
 {
     public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
     {
         public DealDamageHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(DealDamageEvent evt)
         {
             if (!evt.Target.TryGet(out HealthComponent health))
             {
                 return;
             }
             
             health.Value -= evt.Damage;

             if (health.Value <= 0)
             {
                 EventBus.RaiseEvent(new DestroyEvent(evt.Target));
             }
         }
     }
 }