// namespace Lessons.Lesson19_EventBus
// {
//     public sealed class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
//     {
//         private readonly LevelMap _levelMap;
//
//         public ForceDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
//         {
//             _levelMap = levelMap;
//         }
//
//         protected override void OnHandleEvent(ForceDirectionEvent evt)
//         {
//             var coordinates = evt.Entity.Get<CoordinatesComponent>();
//             var targetCoordinates = coordinates.Value + evt.Direction;
//
//             if (!_levelMap.Entities.HasEntity(targetCoordinates))
//             {
//                 EventBus.RaiseEvent(new MoveEvent(evt.Entity, evt.Direction));
//             }
//             else
//             {
//                 var target = _levelMap.Entities.GetEntity(targetCoordinates);
//                 EventBus.RaiseEvent(new CollideEvent(evt.Entity, target));
//             }
//         }
//     }
// }