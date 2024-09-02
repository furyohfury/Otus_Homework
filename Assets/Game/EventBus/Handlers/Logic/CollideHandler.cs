// namespace Lessons.Lesson19_EventBus
// {
//     public class CollideHandler : BaseHandler<CollideEvent>
//     {
//         public CollideHandler(EventBus eventBus) : base(eventBus)
//         {
//         }
//
//         protected override void OnHandleEvent(CollideEvent evt)
//         {
//             EventBus.RaiseEvent(new DealDamageEvent(evt.Entity, 1));
//             EventBus.RaiseEvent(new DealDamageEvent(evt.Target, 1));
//         }
//     }
// }