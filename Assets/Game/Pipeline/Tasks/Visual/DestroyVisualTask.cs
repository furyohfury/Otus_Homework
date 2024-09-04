 using DG.Tweening;
 using Entities;
 using UnityEngine;

 namespace Lessons.Lesson19_EventBus
 {
     public class DestroyVisualTask : EventTask
     {
         private readonly Entity _entity;

         public DestroyVisualTask(Entity entity)
         {
             _entity = entity;
         }

         protected override void OnRun()
         {
             if (_entity.TryGetData(out HeroViewComponent heroViewComponent))
             {
                heroViewComponent.HeroView.SetActive(false);
             }
         }
     }
 }