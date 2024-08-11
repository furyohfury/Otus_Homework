using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class TakeDamageAnimationMechanics
    {
        private readonly IAtomicObservable<int> _hp;
        private readonly Animator _animator;
        private readonly int _takeDamageEventHash = Animator.StringToHash("TakeDamageEvent");

        public TakeDamageAnimationMechanics(IAtomicObservable<int> hp, Animator animator)
        {
            _hp = hp;
            _animator = animator;
        }

        public void OnEnable()
        {
            _hp.Subscribe(OnHPChanged);
        }

        private void OnHPChanged(int hp)
        {
            if (hp > 0)
            {
                _animator.SetTrigger(_takeDamageEventHash);
            }
        }

        public void OnDisable()
        {
            _hp.Unsubscribe(OnHPChanged);
        }
    }
}