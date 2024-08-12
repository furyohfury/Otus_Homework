using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine
{
    public class Bullet : AtomicObject
    {
        [Get(MoveAPI.MOVE_DIRECTION)]
        public IAtomicVariable<Vector3> MoveDirection => _moveComponent.MoveDirection;

        [SerializeField]
        private int _damage = 1;
        [SerializeField]
        private MoveComponent _moveComponent;
        [SerializeField]
        private AtomicVariable<Rigidbody> _root;

        private MoveMechanics _moveMechanics;

        private void Awake()
        {
            _moveComponent.Compose();
            _moveMechanics = new(_moveComponent.Speed, _moveComponent.MoveDirection, _root, _moveComponent.CanMove);
            AddLogic(_moveMechanics);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate(Time.fixedDeltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAtomicEntity atomicEntity))
            {
                if (atomicEntity.TryGetAction<int>(LifeAPI.TAKE_DAMAGE_ACTION, out var action))
                {
                    action.Invoke(_damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
