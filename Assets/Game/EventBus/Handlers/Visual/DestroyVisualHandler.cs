// namespace Lessons.Lesson19_EventBus
// {
//     public class DestroyVisualHandler : BaseHandler<DestroyEvent>
//     {
//         private readonly VisualPipeline _visualPipeline;
//         
//         public DestroyVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
//         {
//             _visualPipeline = visualPipeline;
//         }
//
//         protected override void OnHandleEvent(DestroyEvent evt)
//         {
//             _visualPipeline.AddTask(new DestroyVisualTask(evt.Entity));
//         }
//     }
// }