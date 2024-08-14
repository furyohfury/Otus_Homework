using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
namespace GameEngine
{
    [RequireComponent(typeof(Collider))]
    public sealed class MeleeAttackHitBox : AtomicEntity
    {
        [SerializeField]
        private Collider _collider;
        private IAtomicValue<int> _damage;

        public void Compose(IAtomicEvent onAttackStartEvent,
                            IAtomicEvent onAttackEndEvent,
                            IAtomicValue<int> damage)
        {
            onAttackStartEvent.Subscribe(Enable);
            onAttackEndEvent.Subscribe(Disable);
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAtomicEntity entity)
                && entity.Is("Character")
                && entity.TryGetAction<int>(LifeAPI.TAKE_DAMAGE_REQUEST, out var action))
            {
                action.Invoke(_damage.Value);
            }
        }

        public void Enable() => _collider.enabled = true;

        public void Disable() => _collider.enabled = false;
    }
}
