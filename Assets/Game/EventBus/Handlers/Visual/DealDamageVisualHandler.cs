using Entities;
using UnityEngine;
using Zenject;

namespace EventBus
{
    public sealed class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly ParticleSystem _particleSystem;

        [Inject]
        public DealDamageVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, ParticleSystem particleSystem) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _particleSystem = particleSystem;
        }

        protected override void OnHandleEvent(DealDamageEvent evt)
        {    
            evt.Target.TryGetData(out StatsComponent statsComponent);
            var damage =statsComponent.Damage;
            var health = statsComponent.CurrentHealth;
            // TODO delete if wont fuck with attack animation callback
            _visualPipeline.AddTask(new DealDamageVisualTask(evt.Target, damage, health, _particleSystem)); 
            _visualPipeline.AddTask(new ChangeStatsVisualTask(evt.Target));
        }
    }
}