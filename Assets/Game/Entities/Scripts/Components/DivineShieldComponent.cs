using System;
using Entities;
using UnityEngine;

namespace EventBus
{
    [Serializable]
    public sealed class DivineShieldComponent : IComponent
    {
        public GameObject DivineShieldView;
    }
}