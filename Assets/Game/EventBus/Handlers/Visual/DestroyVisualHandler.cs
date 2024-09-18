namespace EventBus
{
	public class DestroyVisualHandler : BaseHandler<DestroyEvent>
	{
		private readonly VisualPipeline _visualPipeline;
		private readonly AudioPlayer _audioPlayer;

		public DestroyVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, AudioPlayer audioPlayer) :
			base(eventBus)
		{
			_visualPipeline = visualPipeline;
			_audioPlayer = audioPlayer;
		}

		protected override void OnHandleEvent(DestroyEvent evt)
		{
			_visualPipeline.AddTask(new DestroyVisualTask(evt.Target, _audioPlayer));
		}
	}
}