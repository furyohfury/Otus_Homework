using UnityEngine;

namespace EventBus
{
	public class PlaySoundTask : EventTask
	{
		private readonly AudioClip _clip;
		private readonly AudioPlayer _audioPlayer;

		public PlaySoundTask(AudioClip clip, AudioPlayer audioPlayer)
		{
			_clip = clip;
			_audioPlayer = audioPlayer;
		}

		protected override void OnRun()
		{
			Debug.Log("AbilitySoundTask OnRun");
			_audioPlayer.PlaySound(_clip);
			Finish();
		}
	}
}