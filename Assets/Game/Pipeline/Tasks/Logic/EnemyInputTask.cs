using System;
using Entities;
using UI;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class EnemyInputTask : EventTask
    {
        private readonly EventBus _eventBus;
        private HeroListView _playerHeroListView;
        private CurrentHeroService _currentHeroService;

        [Inject]
        public void Construct(EventBus eventBus, UIService uiservice, CurrentHeroService currentHeroService)
        {
            _eventBus = eventBus;
            _playerHeroListView = uiservice.GetBluePlayer();
            _currentHeroService = currentHeroService;
        }

        protected override void OnRun()
        {
            // TODO if frozen
            // if (_currentHeroService.CurrentHero.TryGetData<Disabled>(out _))
            // {
            //     Finish();
            //     return;
            // }
            var currentHero = CurrentHeroService.CurrentHero;

            var playerHeroViews = _playerHeroListView.GetViews();
            int index = Random.Range(0, playerHeroViews.Length)
            var hero = playerHeroViews[index];
            
            _eventBus.RaiseEvent(new AttackEvent(currentHero, hero)); // TODO hero needs to be heroentity
            Finish();
        }
    }
}