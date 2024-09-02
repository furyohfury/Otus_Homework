// namespace Lessons.Lesson19_EventBus
// {
//     public sealed class DealDamageEffectHandler : BaseHandler<DealDamageEffect>
//     {
//         public DealDamageEffectHandler(EventBus eventBus) : base(eventBus)
//         {
//         }
//
//         protected override void OnHandleEvent(DealDamageEffect evt)
//         {
//             EventBus.RaiseEvent(new DealDamageEvent(evt.Target, evt.ExtraDamage));
//         }
//     }
// }