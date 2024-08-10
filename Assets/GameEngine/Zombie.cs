using Atomic.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine
{
    public sealed class Zombie : AtomicObject
    {
        [SerializeField]
        private ZombieCore _core;

        private void Awake()
        {
            _core.Compose();
            AddLogic(_core.MoveMechanics);
            AddLogic(_core.TargetDetectionMechanics);
            AddLogic(_core.LookAtTargetMechanics);
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate(Time.fixedDeltaTime);
        }

#if UNITY_EDITOR
        private bool _showRadius = false;
        [Button]
        public void ShowDetectionRadius()
        {
            _showRadius = !_showRadius;
        }

        private void OnDrawGizmos()
        {
            if (!_showRadius) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _core.Radius.Value);
        }
#endif
    }
}
