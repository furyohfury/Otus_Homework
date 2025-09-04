using System;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

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

		protected override async void OnRun()
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
					var clip = clips[randomIndex];
					_audioPlayer.PlaySound(clip);
					await Task.Delay(TimeSpan.FromSeconds(clip.length));
				}
			}

			Finish();
		}
	}
}