using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMoveController : MonoBehaviour, IOnFixedUpdateListener
    {
        [SerializeField] private InputListener _inputSystem;
        [SerializeField] private MoveComponent _playerMoveComponent;

        private void Awake()
        {
            IGameStateListener.Register(this);
        }
        
        public void OnFixedUpdate()
        {
            var direction = new Vector2(_inputSystem.HorizontalDirection, 0);
            _playerMoveComponent.MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
        }
    }
}