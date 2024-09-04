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
             _source.TryGetData(out HeroViewComponent sourceHeroViewComponent);
             _target.TryGetData(out HeroViewComponent targetHeroViewComponent);

             sourceHeroViewComponent.HeroView.AnimateAttack(targetHeroViewComponent.HeroView);
             // TODO on unitasksource finish invoke Finish() here
         }
     }
 }