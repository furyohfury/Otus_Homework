using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
namespace GameEngine
{
    [RequireComponent(typeof(Collider))]
    public sealed class MeleeAttackHitBox : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;
        private IAtomicValue<int> _damage;

        public void Compose(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAtomicEntity entity)
                && entity.Is("Character") // or mb easier w/ collision matrix i dunno
                && entity.TryGetAction<int>(LifeAPI.TAKE_DAMAGE_ACTION, out var action))
            {
                action.Invoke(_damage.Value);
            }
        }

        public void Enable() => _collider.enabled = true;

        public void Disable() => _collider.enabled = false;
    }
}
