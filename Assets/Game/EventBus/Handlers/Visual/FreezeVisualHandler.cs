namespace EventBus
{   
    public sealed class FreezeVisualHandler : BaseHandler<FreezeEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly GameObject _freezeEffectPrefab;

        public FreezeVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnHandleEvent(FreezeEvent evt)
        {    
            _visualPipeline.AddTask(new FreezeVisualTask(evt.Target, _freezeEffectPrefab));
        }
    }

      

    
}