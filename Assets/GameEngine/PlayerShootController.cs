using Atomic.Extensions;
using Atomic.Objects;
using Zenject;

namespace GameEngine
{
    public sealed class PlayerShootController : IInitializable
    {
        private readonly IAtomicEntity _player;
        private readonly InputListener _inputListener;

        public PlayerShootController(IAtomicEntity player, InputListener inputListener)
        {
            _player = player;
            _inputListener = inputListener;
        }

        void IInitializable.Initialize()
        {
            if (_player.TryGetAction(ShootAPI.SHOOT_REQUEST, out var action))
            {
                _inputListener.ShootRequest.Subscribe(action);
            }
            else
            {
                throw new System.Exception("Didnt find shoot request on player");
            }
        }
    }
}
