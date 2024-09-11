// namespace EventBus
// {
//     public sealed class PushEffectHandler : BaseHandler<PushEffect>
//     {
//         public PushEffectHandler(EventBus eventBus) : base(eventBus)
//         {
//         }
//
//         protected override void OnHandleEvent(PushEffect evt)
//         {
//             var entityPosition = evt.Source.Get<CoordinatesComponent>().Value;
//             var targetPosition = evt.Target.Get<CoordinatesComponent>().Value;
//             
//             var direction = targetPosition - entityPosition;
//             
//             EventBus.RaiseEvent(new ForceDirectionEvent(evt.Target, direction));
//         }
//     }
// }