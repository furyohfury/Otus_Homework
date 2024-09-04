 using Entities;

 namespace Lessons.Lesson19_EventBus
 {
     public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
     {
         public DealDamageHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(DealDamageEvent evt)
         {
             if (!evt.Target.TryGetData(out HealthComponent health))
             {
                 return;
             }
             
             health.CurrentHealth -= evt.Damage;

             if (health.CurrentHealth <= 0)
             {
                 EventBus.RaiseEvent(new DestroyEvent(evt.Target));
             }
         }
     }
 }