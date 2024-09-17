using UnityEngine;
using Zenject;

namespace EventBus
{
	public sealed class DamageAllVisualHandler : BaseHandler<DamageAllEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly ParticleSystem _particleSystem;
		private readonly AudioPlayer _audioPlayer;

		[Inject]
		public DamageAllVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, ParticleSystem particleSystem,
			AudioPlayer audioPlayer) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_particleSystem = particleSystem;
			_audioPlayer = audioPlayer;
		}

		protected override void OnHandleEvent(DamageAllEvent evt)
		{
			Debug.Log("DamageAllVisualHandler");
			_visualPipeline.AddTask(new DamageAllVisualTask(_particleSystem, evt.Source));

			var clips = evt.AudioClips;
			if (clips == null) return;
			var clip = clips[Random.Range(0, clips.Length)];
			_visualPipeline.AddTask(new PlaySoundTask(clip, _audioPlayer));
		}
	}
}