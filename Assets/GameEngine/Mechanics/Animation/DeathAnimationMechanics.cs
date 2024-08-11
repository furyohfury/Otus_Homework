using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    public sealed class DeathAnimationMechanics
    {
        private readonly int _isDeadHash = Animator.StringToHash("IsDead");
        private readonly IAtomicObservable<bool> _isAlive;
        private readonly Animator _animator;

        public DeathAnimationMechanics(IAtomicObservable<bool> isAlive, Animator animator)
        {
            _isAlive = isAlive;
            _animator = animator;
        }

        public void OnEnable()
        {
            _isAlive.Subscribe(OnDead);
        }

        private void OnDead(bool alive)
        {
            if (!alive)
            {
                _animator.SetTrigger(_isDeadHash);
                if (_animator.layerCount > 1)
                {
                    var bodyLayer = _animator.GetLayerIndex("Body");
                    var legsLayer = _animator.GetLayerIndex("Legs");
                    _animator.SetLayerWeight(bodyLayer, 0);
                    _animator.SetLayerWeight(legsLayer, 0);
                }
            }
        }

        public void OnDisable()
        {
            _isAlive.Unsubscribe(OnDead);
        }
    }
}