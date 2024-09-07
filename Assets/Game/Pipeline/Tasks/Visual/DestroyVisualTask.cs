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
                 Debug.Log($"DestroyVisualTask of {_entity.gameObject.name}");
                 heroViewComponent.HeroView.gameObject.SetActive(false);
                 // Object.Destroy(heroViewComponent.HeroView.gameObject);
             }
             Finish();
         }
     }
 }