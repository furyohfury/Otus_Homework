 using DG.Tweening;
 using Entities;
 using UnityEngine;

 namespace EventBus
 {
     public class DestroyGOVisualTask : EventTask
     {
         private readonly GameObject _gameObject;

         public DestroyGOVisualTask(GameObject gameObject)
         {
             _gameObject = gameObject;
         }

         protected override void OnRun()
         {             
                 Object.Destroy(_gameObject);
             Finish();
         }
     }
 }