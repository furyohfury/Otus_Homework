using System;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EventBus
{
	public class DestroyVisualTask : EventTask
	{
		private readonly Entity _entity;
		private readonly AudioPlayer _audioPlayer;

		public DestroyVisualTask(Entity entity, AudioPlayer audioPlayer)
		{
			_entity = entity;
			_audioPlayer = audioPlayer;
		}

		protected override async void OnRun()
		{
			Debug.Log($"DestroyVisualTask of {_entity.gameObject.name}");
			var heroViewComponent = _entity.GetData<HeroViewComponent>();
			heroViewComponent.HeroView.gameObject.SetActive(false);

			if (_entity.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.DeathClips;
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