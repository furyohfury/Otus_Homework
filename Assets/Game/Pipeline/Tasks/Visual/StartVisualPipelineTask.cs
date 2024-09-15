using UnityEngine;
using Zenject;

namespace EventBus.Visual
{
    public class StartVisualPipelineTask : EventTask
    {
        private VisualPipeline _visualPipeline;

        [Inject]
        public void Construct(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            Debug.Log("VisualPipelineStart task OnRun");
            _visualPipeline.OnFinished += OnFinishedPipeline;
            _visualPipeline.RunNextTask();
        }
        
        private void OnFinishedPipeline()
        {
            Debug.Log("VisualPipeline finished and cleared");
    
            _visualPipeline.OnFinished -= OnFinishedPipeline;
            _visualPipeline.ClearAll();
            Finish();
        }
    }
}