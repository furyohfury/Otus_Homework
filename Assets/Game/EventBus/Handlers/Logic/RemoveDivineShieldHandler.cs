 using Entities;
 using UnityEngine;

 namespace Lessons.Lesson19_EventBus
 {
     public sealed class RemoveDivineShieldHandler : BaseHandler<RemoveDivineShieldEvent>
     {
         public RemoveDivineShieldHandler(EventBus eventBus) : base(eventBus)
         {
         }

         protected override void OnHandleEvent(RemoveDivineShieldEvent evt)
         {             
             evt.Target.RemoveData<DivineShieldComponent>();
         }
     }
 }