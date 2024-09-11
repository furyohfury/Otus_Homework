namespace Game.EventBus
{
    public sealed class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public DealDamageVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnHandleEvent(DealDamageEvent evt)
        {    
            evt.Target.TryGetData(out StatsComponent statsComponent);
            var damage =statsComponent.Damage;
            var health = statsComponent.CurrentHealth;
            _visualPipeline.AddTask(new DealDamageVisualTask(evt.Target, damage, health));
        }
    }
}