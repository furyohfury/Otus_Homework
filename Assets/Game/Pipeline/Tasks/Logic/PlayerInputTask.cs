using System;
using Entities;
using UI;
using UnityEngine;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
    public class PlayerInputTask : EventTask
    {
        private EventBus _eventBus;
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
            Debug.Log("Run PlayerInputTask");
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
            Debug.Log($"Clicked hero {hero.name}");
            var currentHero = _currentHeroService.CurrentHero;
            _eventBus.RaiseEvent(new AttackEvent(currentHero, hero.GetComponent<HeroEntity>())); 
            // TODO hero needs to be heroentity
            Finish();
        }
    }
}