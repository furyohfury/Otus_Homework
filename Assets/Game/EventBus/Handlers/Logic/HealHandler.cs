 using Entities;
 using EventBus;
 using UnityEngine;
 using Zenject;
 using Random = UnityEngine.Random;

 namespace EventBus
 {
     public sealed class HealHandler : BaseHandler<HealEvent>
     {
         [Inject]
         public HealHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(HealEvent evt)
         {             
             if (!evt.Entity.TryGetData(out StatsComponent stats))
             {
                return;
             }

             stats.CurrentHealth = Mathf.Max(stats.CurrentHealth + evt.Amount, stats.MaxHealth);
         }
     }
 }