using System;
using Entities;
using UI;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class PlayerInputTask : EventTask
    {
        private readonly EventBus _eventBus;
        private HeroListView _enemyHeroListView;
        private CurrentHeroService _currentHeroService;

        [Inject]
        public void Construct(EventBus eventBus, UIService uiservice, CurrentHeroService currentHeroService)
        {
            _eventBus = eventBus;
            _enemyHeroListView = uiservice.GetRedPlayer();
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
            _enemyHeroListView.OnHeroClicked += OnHeroClicked;
        }

        protected override void OnFinish()
        {
            _enemyHeroListView.OnHeroClicked -= OnHeroClicked;
        }
        
        private void OnHeroClicked(HeroView hero)
        {
            var currentHero = CurrentHeroService.CurrentHero;
            _eventBus.RaiseEvent(new AttackEvent(currentHero, hero)); // TODO hero needs to be heroentity
            Finish();
        }
    }
}