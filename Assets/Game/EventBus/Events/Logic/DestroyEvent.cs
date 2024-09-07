 using Entities;

 namespace Lessons.Lesson19_EventBus
 {
     public struct DestroyEvent : IEvent
     {
         public readonly Entity Target;

         public DestroyEvent(Entity target)
         {
             Target = target;
         }
     }
 }