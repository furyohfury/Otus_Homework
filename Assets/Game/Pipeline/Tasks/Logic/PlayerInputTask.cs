using System;
using Entities;
using UI;
using UnityEngine;

namespace Lessons.Lesson19_EventBus
{
    public class PlayerInputTask : EventTask
    {
        private readonly EventBus _eventBus;
        private HeroListView _heroListView;
        private HeroEntity _currentHero;

        [Inject]
        public void Construct(EventBus eventBus, UIService uiservice)
        {
            _eventBus = eventBus;
            _heroListView = uiservice.GetRedPlayer();
        }

        protected override void OnRun()
        {
            _heroListView.OnHeroClicked += OnHeroClicked;
        }

        protected override void OnFinish()
        {
            _heroListView.OnHeroClicked -= OnHeroClicked;
        }
        
        private void OnHeroClicked(HeroView hero)
        {
            _eventBus.RaiseEvent(new AttackEvent());
            Finish();
        }
    }
}