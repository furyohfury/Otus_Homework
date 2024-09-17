using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class DamageAllVisualHandler : BaseHandler<DamageAllEffect>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly AudioPlayer _audioPlayer;

		[Inject]
		public DamageAllVisualHandler(EventBus eventBus, VisualPipeline visualPipeline,
			AudioPlayer audioPlayer) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_audioPlayer = audioPlayer;
		}

		protected override void OnHandleEvent(DamageAllEffect evt)
		{
			Debug.Log("DamageAllVisualHandler");
			_visualPipeline.AddTask(new DamageAllVisualTask(evt.ParticleSystem, evt.Source));

			var clips = evt.AudioClips;
			if (clips == null) return;
			var clip = clips[Random.Range(0, clips.Length)];
			_visualPipeline.AddTask(new PlaySoundTask(clip, _audioPlayer));
		}
	}
}