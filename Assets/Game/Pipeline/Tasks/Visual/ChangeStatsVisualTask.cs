using Entities;
using UnityEngine;

namespace EventBus
{
	public class ChangeStatsVisualTask : EventTask
	{
		private readonly Entity _target;
		private readonly AudioPlayer _audioPlayer;

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

			if (stats.CurrentHealth > 0
			    && stats.CurrentHealth <= stats.MaxHealth * 0.2f
			    && _target.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.LowHealthClips;
				if (clips != null)
				{
					var randomIndex = Random.Range(0, clips.Length);
					_audioPlayer.PlaySound(clips[randomIndex]);
				}
			}

			Finish();
		}
	}
}