using UnityEngine;

namespace Lessons.Lesson19_EventBus.Visual
{
    public class StartVisualPipelineTask : EventTask
    {
        private readonly VisualPipeline _visualPipeline;

        public StartVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            Debug.Log("Run visual task");
            _visualPipeline.OnFinished += OnFinishedPipeline;
            _visualPipeline.RunNextTask();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnFinishedPipeline;
        }

        private void OnFinishedPipeline()
        {
            _visualPipeline.ClearAll();
            Finish();
        }
    }
}