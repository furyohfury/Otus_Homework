using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class Character : AtomicObject
    {
        // Interfaces
        [Get(MoveAPI.MoveDirection)]
        public IAtomicVariable<Vector3> MoveDirection => _core.MoveComponent.MoveDirection;


        [SerializeField]
        private CharacterCore _core;

        private void Awake()
        {
            
        }

        [Inject]
        private void Compose(Camera camera) // todo inject cringe?
        {
            _core.Compose(camera);
            AddLogic(_core.MoveMechanics);
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
    }
}
