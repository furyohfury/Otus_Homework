using System;
using System.Threading.Tasks;
using Entities;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace EventBus
{
	public sealed class StartTurnTask : EventTask
	{
		private readonly AudioPlayer _audioPlayer;
		private readonly CurrentHeroService _currentHeroService;

		[Inject]
		public StartTurnTask(AudioPlayer audioPlayer, CurrentHeroService currentHeroService)
		{
			_audioPlayer = audioPlayer;
			_currentHeroService = currentHeroService;
		}

		protected override async void OnRun()
		{
			Debug.Log("StartTurnTask OnRun");
			var currentHero = _currentHeroService.CurrentHero;

			var heroViewComponent = currentHero.GetData<HeroViewComponent>();
			heroViewComponent.HeroView.SetActive(true);

			if (currentHero.TryGetData(out HeroSoundComponent heroSoundComponent))
			{
				var clips = heroSoundComponent.StartTurnClips;
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