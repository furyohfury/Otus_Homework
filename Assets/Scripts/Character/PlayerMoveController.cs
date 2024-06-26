using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class PlayerMoveController : IInitializable, IOnFixedUpdateListener
    {
        [SerializeField] private InputListener _inputSystem;
        [SerializeField] private Player _player;

        [Inject]
        public PlayerMoveController(InputListener inputSystem, Player player)
        {
            _inputSystem = inputSystem;
            _player = player;
        }

        void IInitializable.Initialize()
        {
            IGameStateListener.Register(this);
        }

        public void OnFixedUpdate(float delta)
        {
            var direction = new Vector2(_inputSystem.HorizontalDirection, 0);
            _player.Move(direction * Time.fixedDeltaTime);
        }
    }
}