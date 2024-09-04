using System;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
    public class TurnPipelineRunner : IInitializable
    {
        private PlayerTurnPipeline _pipeline;
        
        [Inject]
        public TurnPipelineRunner(PlayerTurnPipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        void IInitializable.Initialize()
        {
            _pipeline.OnFinished += OnFinished;
            Run();
        }

        private void OnFinished()
        {
            _pipeline.Reset();
            _pipeline.RunNextTask();
        }

        public void Run()
        {
            _pipeline.RunNextTask();
        }

    }
}