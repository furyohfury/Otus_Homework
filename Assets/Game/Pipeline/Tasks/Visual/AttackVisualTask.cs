 using DG.Tweening;
 using Entities;
 using UnityEngine;

 namespace Lessons.Lesson19_EventBus
 {
     public class AttackVisualTask : EventTask
     {
         private readonly Entity _source;
         private readonly Entity _target;


         public AttackVisualTask(Entity source, Entity target)
         {
             _source = source;
             _target = target;
         }

         protected override void OnRun()
         {
            var sourceView = _source.TryGetData<HeroViewComponent>();
             var targetView = _target.TryGetData<HeroViewComponent>();

             sourceView.AnimateAttack(targetView);
             // TODO on unitasksource finish invoke Finish() here
         }
     }
 }