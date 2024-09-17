 using System;
 using Entities;
 using UnityEngine;

 namespace EventBus
 {
     public sealed class RemoveDivineShieldHandler : BaseHandler<RemoveDivineShieldEvent>
     {
         public RemoveDivineShieldHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(RemoveDivineShieldEvent evt)
         {
             if (!evt.Entity.TryRemoveData<DivineShieldComponent>())
             {
                 throw new Exception($"{evt.Entity.name} has no divine shield");
             }
         }
     }
 }