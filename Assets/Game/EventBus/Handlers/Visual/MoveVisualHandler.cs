//
// namespace Lessons.Lesson19_EventBus
// {
//     public class MoveVisualHandler : BaseHandler<MoveEvent>
//     {
//         private readonly LevelMap _levelMap;
//         private readonly VisualPipeline _visualPipeline;
//         
//         public MoveVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, LevelMap levelMap) : base(eventBus)
//         {
//             _visualPipeline = visualPipeline;
//             _levelMap = levelMap;
//         }
//
//         protected override void OnHandleEvent(MoveEvent evt)
//         {
//             var component = evt.Entity.Get<CoordinatesComponent>();
//             var targetPosition = _levelMap.Tiles.CoordinatesToPosition(component.Value);
//             
//             _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, targetPosition));
//         }
//     }
// }