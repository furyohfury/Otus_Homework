 using Entities;

 namespace Lessons.Lesson19_EventBus
 {
     public struct DestroyEvent : IEvent
     {
         public Entity Entity;

         public DestroyEvent(Entity entity)
         {
             Entity = entity;
         }
     }
 }