namespace EventBus
{
    public class AbilitySoundTask : EventTask
     {
         private readonly Entity _source;
         private AudioPlayer _audioPlayer;

         public AbilitySoundTask(Entity source, AudioPlayer audioPlayer)
         {
             _source = source;
             _audioPlayer = audioPlayer;
         }

         protected override void OnRun()
         {
            Debug.Log($"AbilitySoundTask of {_entity.gameObject.name}");

            if (currentHero.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.AbilityClips;
				if (clips == null) continue;
				
				var randomIndex = Random.Range(0, clips.Length);
				_audioPlayer.PlaySound(clips[randomIndex]);
			}
             Finish();
         }
     }
}