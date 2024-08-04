using Atomic.Elements;

namespace GameEngine
{
    public sealed class TakeDamageMechanics
    {
        public IAtomicEvent<int> TakeDamageEvent;
        public IAtomicVariable<bool> IsAlive;
        private readonly IAtomicVariable<int> _hitPoints;

        public TakeDamageMechanics(
            IAtomicEvent<int> takeDamageEvent,
            IAtomicVariable<bool> isAlive,
            IAtomicVariable<int> hitPoints)
        {
            TakeDamageEvent = takeDamageEvent;
            IsAlive = isAlive;
            _hitPoints = hitPoints;
            TakeDamageEvent.Subscribe(TakeDamage);
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive.Value)
            {
                return;
            }

            _hitPoints.Value -= damage;

            if (_hitPoints.Value <= 0)
            {
                IsAlive.Value = false;
            }
        }
    }
}
