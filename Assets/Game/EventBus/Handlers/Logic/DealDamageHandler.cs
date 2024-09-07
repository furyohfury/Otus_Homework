 using Entities;
 using UnityEngine;

 namespace Lessons.Lesson19_EventBus
 {
     public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
     {
         public DealDamageHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(DealDamageEvent evt)
         {
             Debug.Log($"DealDamage handled. Target: {evt.Target.gameObject.name}, damage: {evt.Damage}");
             if (!evt.Target.TryGetData(out HealthComponent health))
             {
                 return;
             }
             
             health.ChangeCurrentHealth(-evt.Damage);

             if (health.CurrentHealth <= 0)
             {
                 EventBus.RaiseEvent(new DestroyEvent(evt.Target));
             }
         }
     }
 }