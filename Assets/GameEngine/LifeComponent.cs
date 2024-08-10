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

        public void Compose()
        {
            TakeDamageEvent.Subscribe(TakeDamage);
        }
        public void TakeDamage(int damage)
        {
            if (!IsAlive.Value)
            {
                return;
            }

            HitPoints.Value -= damage;

            if (HitPoints.Value <= 0)
            {
                IsAlive.Value = false;
            }
        }

    }
}
