 using DG.Tweening;
 using Entities;
 using UnityEngine;

 namespace EventBus
 {
     public class DestroyVisualTask : EventTask
     {
         private readonly Entity _entity;
         private AudioPlayer _audioPlayer;

         public DestroyVisualTask(Entity entity, AudioPlayer audioPlayer)
         {
             _entity = entity;
             _audioPlayer = audioPlayer;
         }

         protected override void OnRun()
         {
            Debug.Log($"DestroyVisualTask of {_entity.gameObject.name}");
             heroViewComponent = _entity.GetData<HeroViewComponent>();                 
                 heroViewComponent.HeroView.gameObject.SetActive(false);

            if (currentHero.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.DeathClips;
				if (clips == null) continue;
				
				var randomIndex = Random.Range(0, clips.Length);
				_audioPlayer.PlaySound(clips[randomIndex]);
			}
                 // Object.Destroy(heroViewComponent.HeroView.gameObject);
             Finish();
         }
     }
 }