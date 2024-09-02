using System;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
    public class PlayerTurnPipelineRunner : IInitializable
    {
        private PlayerTurnPipeline _pipeline;
        private HeroEntity _activeHero;
        private HeroEntity[] _playerHeroes;
        
        [Inject]
        public PlayerTurnPipelineRunner(PlayerTurnPipeline pipeline)
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