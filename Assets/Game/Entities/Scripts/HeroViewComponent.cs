using System;
using UI;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public sealed class HeroViewComponent : IComponent
    {
        public readonly HeroView HeroView;
        public Transform Container;

        public HeroViewComponent(HeroView view, Transform container)
        {
            HeroView = view;
            Container = container;
        }
    }
}