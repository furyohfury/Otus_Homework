using UnityEngine;

namespace EventBus
{   
    public sealed class FreezeVisualHandler : BaseHandler<FreezeEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly GameObject _freezeEffectPrefab;

        public FreezeVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, GameObject freezeEffectPrefab) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _freezeEffectPrefab = freezeEffectPrefab;
        }

        protected override void OnHandleEvent(FreezeEvent evt)
        {    
            _visualPipeline.AddTask(new FreezeVisualTask(evt.Target, _freezeEffectPrefab));
        }
    }

      

    
}