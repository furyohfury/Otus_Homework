using System;
using Atomic.Elements;

namespace GameEngine
{
    [Serializable]
    public class LifeComponent
    {
        public AtomicEvent<int> TakeDamageEvent;
        public AtomicVariable<bool> IsAlive = new(true);
        public AtomicVariable<int> HitPoints = new(5);

        private TakeDamageMechanics _takeDamageMechanics;

        public void Compose()
        {
            _takeDamageMechanics = new(TakeDamageEvent, IsAlive, HitPoints);
        }

    }
}
