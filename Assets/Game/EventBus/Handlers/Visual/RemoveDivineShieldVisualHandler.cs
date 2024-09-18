namespace EventBus
{
	public sealed class RemoveDivineShieldVisualHandler : BaseHandler<RemoveDivineShieldEvent>
	{
		private readonly VisualPipeline _visualPipeline;

		public RemoveDivineShieldVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
		{
			_visualPipeline = visualPipeline;
		}

		protected override void OnHandleEvent(RemoveDivineShieldEvent evt)
		{
			_visualPipeline.AddTask(new DestroyGOVisualTask(evt.ShieldView));
		}
	}
}