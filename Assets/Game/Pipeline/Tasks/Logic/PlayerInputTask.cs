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
            _eventBus.RaiseEvent(new AttackEvent(hero.GetComponent<HeroEntity>()));
            Finish();
        }
    }
}