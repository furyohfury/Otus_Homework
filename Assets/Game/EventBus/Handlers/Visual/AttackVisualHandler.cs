namespace Lessons.Lesson19_EventBus
{
    public sealed class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public AttackVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnHandleEvent(AttackEvent evt)
        {    
            _visualPipeline.AddTask(new AttackVisualTask(evt.Source, evt.Target));
        }
    }
}