 namespace Lessons.Lesson19_EventBus
 {
     public sealed class DestroyHandler : BaseHandler<DestroyEvent>
     {         
         
         public DestroyHandler(EventBus eventBus) : base(eventBus)
         {
             
         }

         protected override void OnHandleEvent(DestroyEvent evt)
         {             
             if (evt.Entity.TryGetData(out DestroyComponent destroyComponent))
              {
                  destroyComponent.Destroy();
              }
         }
     }
 }