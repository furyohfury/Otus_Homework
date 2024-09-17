using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class HealRandomAllyVisualHandler : BaseHandler<HealRandomAllyEffect>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly AudioPlayer _audioPlayer;

		[Inject]
		public HealRandomAllyVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, AudioPlayer audioPlayer) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_audioPlayer = audioPlayer;
		}

		protected override void OnHandleEvent(HealRandomAllyEffect evt)
		{
			var clips = evt.AudioClips;
			if (clips == null) return;
			var clip = clips[Random.Range(0, clips.Length)];
			_visualPipeline.AddTask(new PlaySoundTask(clip, _audioPlayer));
		}
	}
}