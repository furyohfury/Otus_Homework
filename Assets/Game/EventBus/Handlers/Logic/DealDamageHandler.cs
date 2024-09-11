 using Entities;
 using EventBus;
 using UnityEngine;

 namespace EventBus
 {
     public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
     {
         public DealDamageHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(DealDamageEvent evt)
         {             
             if (!evt.Target.TryGetData(out StatsComponent statsComponent))
             {
                 return;
             }
             
             if (evt.Target.HasData<DivineShieldComponent>())
             {
                EventBus.RaiseEvent(new RemoveDivineShieldEvent(evt.Target));
                return;
             }

             Debug.Log($"DealDamage handled. Target: {evt.Target.gameObject.name}, damage: {evt.Damage}");
             statsComponent.CurrentHealth -= evt.Damage;

             if (statsComponent.CurrentHealth <= 0)
             {
                 EventBus.RaiseEvent(new DestroyEvent(evt.Target));
             }
         }
     }
 }