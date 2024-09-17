using UnityEngine;
using Zenject;

namespace EventBus
{
    public sealed class HealVisualHandler : BaseHandler<HealEvent>
     {
        private ParticleSystem _particleSystem;
        private readonly VisualPipeline _visualPipeline;
        private AudioPlayer _audioPlayer;

         [Inject]
         public HealVisualHandler(EventBus eventBus, ParticleSystem particleSystem, VisualPipeline visualPipeline, AudioPlayer audioPlayer) : base(eventBus)
         {
            _particleSystem = particleSystem;
            _visualPipeline = visualPipeline;
            _audioPlayer = audioPlayer;
         }

         protected override void OnHandleEvent(HealEvent evt)
         {             
             _visualPipeline.AddTask(new HealVisualTask(evt.Entity, _particleSystem));
             _visualPipeline.AddTask(new ChangeStatsVisualTask(evt.Entity, _audioPlayer));
         }
     }
}