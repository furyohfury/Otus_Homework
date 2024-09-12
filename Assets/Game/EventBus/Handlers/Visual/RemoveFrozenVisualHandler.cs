namespace EventBus
{
    public sealed class RemoveFrozenVisualHandler : BaseHandler<RemoveFrozenEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public RemoveFrozenHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnHandleEvent(RemoveFrozenEvent evt)
        {    
            var view = evt.Target.GetData<FrozenComponent>().View;
            _visualPipeline.AddTask(new DestroyGOVisualTask(view));
        }
    }
}