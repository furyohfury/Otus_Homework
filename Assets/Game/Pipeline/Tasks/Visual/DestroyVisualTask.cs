// using DG.Tweening;
// using Entities;
// using UnityEngine;
//
// namespace Lessons.Lesson19_EventBus
// {
//     public class DestroyVisualTask : EventTask
//     {
//         private readonly IEntity _entity;
//         private readonly float _duration;
//
//         public DestroyVisualTask(IEntity entity, float duration = .4f)
//         {
//             _duration = duration;
//             _entity = entity;
//         }
//
//         protected override void OnRun()
//         {
//             var transform = _entity.Get<TransformComponent>().Value;
//             transform.DOScale(Vector3.zero, _duration).OnComplete(Finish);
//         }
//     }
// }