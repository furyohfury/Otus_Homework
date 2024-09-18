namespace EventBus
{
	public sealed class RemoveFrozenVisualHandler : BaseHandler<RemoveFrozenEvent>
	{
		private readonly VisualPipeline _visualPipeline;

		public RemoveFrozenVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
		{
			_visualPipeline = visualPipeline;
		}

		protected override void OnHandleEvent(RemoveFrozenEvent evt)
		{
			_visualPipeline.AddTask(new DestroyGOVisualTask(evt.View));
		}
	}
}