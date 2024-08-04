using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class CharacterMoveController : ITickable
    {
        private readonly IAtomicObject _character;
        private readonly InputListener _inputListener;

        public CharacterMoveController(IAtomicObject character, InputListener inputListener)
        {
            _character = character;
            _inputListener = inputListener;
        }

        void ITickable.Tick()
        {
            var moveDirection = _character.GetVariable<Vector3>(MoveAPI.MoveDirection);
            moveDirection.Value = _inputListener.Direction;
        }
    }
}
