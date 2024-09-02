// using DG.Tweening;
// using Entities;
// using UnityEngine;
//
// namespace Lessons.Lesson19_EventBus
// {
//     public class MoveVisualTask : EventTask
//     {
//         private readonly IEntity _entity;
//         private readonly Vector3 _targetPosition;
//         private readonly float _duration;
//
//         public MoveVisualTask(IEntity entity, Vector3 targetPosition, float duration = .3f)
//         {
//             _entity = entity;
//             _targetPosition = targetPosition;
//             _duration = duration;
//         }
//
//         protected override void OnRun()
//         {
//             TransformComponent component = _entity.Get<TransformComponent>();
//             component.Value.DOMove(_targetPosition, _duration).OnComplete(Finish);
//         }
//     }
// }