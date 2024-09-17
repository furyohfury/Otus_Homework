namespace EventBus
{
    public sealed class AbilitySoundHandler : BaseHandler<ICombatEvent> // TODO check if works
    {
        private readonly VisualPipeline _visualPipeline;
         private AudioPlayer _audioPlayer;

        [Inject]
        public AbilitySoundHandler(EventBus eventBus, VisualPipeline visualPipeline, AudioPlayer audioPlayer) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _audioPlayer = audioPlayer;
        }   

        protected override void OnHandleEvent(ICombatEvent evt)
        {    
            _visualPipeline.AddTask(new AbilitySoundVisualTask(evt.Source, _audioPlayer));
        }
    }
}
