using Zenject;

namespace EventBus
{
	public sealed class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly AudioPlayer _audioPlayer;

		[Inject]
		public DealDamageVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, AudioPlayer audioPlayer) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_audioPlayer = audioPlayer;
		}

		protected override void OnHandleEvent(DealDamageEvent evt)
		{
			_visualPipeline.AddTask(new ChangeStatsVisualTask(evt.Target, _audioPlayer));
		}
	}
}