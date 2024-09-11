using Entities;
using UnityEngine;
using Zenject;

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

		protected override void OnRun()
		{
			Debug.Log("StartTurnTask OnRun");
			var currentHero = _currentHeroService.CurrentHero;

			currentHero.TryGetData(out HeroViewComponent heroViewComponent);
			currentHero.TryGetData(out HeroStartTurnSoundComponent heroStartTurnSoundComponent);

			heroViewComponent.HeroView.SetActive(true);

			var clips = heroStartTurnSoundComponent.AudioClips;
			var randomIndex = Random.Range(0, clips.Length);
			_audioPlayer.PlaySound(clips[randomIndex]);
			Finish();
		}
	}
}