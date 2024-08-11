using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using Zenject;

namespace GameEngine
{
    public sealed class CharacterShootController : IInitializable
    {
        private readonly IAtomicEntity _character;
        private readonly InputListener _inputListener;

        public CharacterShootController(IAtomicEntity character, InputListener inputListener)
        {
            _character = character;
            _inputListener = inputListener;
        }

        void IInitializable.Initialize()
        {
            if (_character.TryGetAction(ShootAPI.SHOOT_REQUEST, out IAtomicAction action))
            {
                _inputListener.ShootRequest.Subscribe(action);
            }
            else
            {
                throw new System.NullReferenceException("Didnt find shoot request on player");
            }
        }
    }
}
