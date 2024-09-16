using UnityEngine;
using Zenject;

namespace EventBus
{
    public sealed class HealVisualHandler : BaseHandler<HealEvent>
     {
        private ParticleSystem _particleSystem;
        private readonly VisualPipeline _visualPipeline;

         [Inject]
         public HealVisualHandler(EventBus eventBus, ParticleSystem particleSystem, VisualPipeline visualPipeline) : base(eventBus)
         {
            _particleSystem = particleSystem;
            _visualPipeline = visualPipeline;
         }

         protected override void OnHandleEvent(HealEvent evt)
         {             
             _visualPipeline.AddTask(new HealVisualTask(evt.Entity, _particleSystem));
             _visualPipeline.AddTask(new ChangeStatsVisualTask(evt.Entity));
         }
     }
}