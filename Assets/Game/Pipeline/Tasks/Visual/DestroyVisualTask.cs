using Entities;
using UnityEngine;

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

		protected override void OnRun()
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
					_audioPlayer.PlaySound(clips[randomIndex]);
				}
			}

			// Object.Destroy(heroViewComponent.HeroView.gameObject);
			Finish();
		}
	}
}