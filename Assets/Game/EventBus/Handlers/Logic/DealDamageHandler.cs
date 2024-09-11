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
             if (!evt.Target.TryGetData(out HealthComponent health))
             {
                 return;
             }
             
             if (evt.Target.HasData<DivineShieldComponent>())
             {
                EventBus.RaiseEvent(new RemoveDivineShieldEvent(evt.Target));
                return;
             }

             Debug.Log($"DealDamage handled. Target: {evt.Target.gameObject.name}, damage: {evt.Damage}");
             health.ChangeCurrentHealth(-evt.Damage);

             if (health.CurrentHealth <= 0)
             {
                 EventBus.RaiseEvent(new DestroyEvent(evt.Target));
             }
         }
     }
 }