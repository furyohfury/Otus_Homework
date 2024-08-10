using Atomic.Elements;
using Atomic.Objects;

namespace GameEngine
{
    public class CooldownMechanics : IAtomicUpdate
    {
        private readonly IAtomicVariable<float> _cooldown;

        public CooldownMechanics(IAtomicVariable<float> cooldown)
        {
            _cooldown = cooldown;
        }

        void IAtomicUpdate.OnUpdate(float deltaTime)
        {
            if (_cooldown.Value > 0)
            {
                _cooldown.Value -= deltaTime;
            }
        }
    }
}
