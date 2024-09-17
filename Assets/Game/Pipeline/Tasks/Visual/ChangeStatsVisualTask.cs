using Entities;
using UnityEngine;

namespace EventBus
{
   public class ChangeStatsVisualTask : EventTask
	{
		private readonly Entity _target;
		private AudioPlayer _audioPlayer;

		public ChangeStatsVisualTask(Entity target, AudioPlayer audioPlayer)
		{
			_target = target;
			_audioPlayer = audioPlayer;
		}

		protected override void OnRun()
		{
			Debug.Log("ChangeStatsVisualTask OnRun");
			var stats = _target.GetData<StatsComponent>();
			var targetHeroViewComponent = _target.GetData<HeroViewComponent>();
			targetHeroViewComponent.HeroView.SetStats($"{stats.Damage}/{stats.CurrentHealth}");

			if (stats.CurrentHP <= stats.MaxHP * 0.2f && currentHero.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.LowHealthClips;
				if (clips == null) continue;
				
				var randomIndex = Random.Range(0, clips.Length);
				_audioPlayer.PlaySound(clips[randomIndex]);
			}	
			Finish();
		}
	} 
}
