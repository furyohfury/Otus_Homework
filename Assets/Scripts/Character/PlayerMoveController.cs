using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private InputListener _inputSystem;
        [SerializeField] private MoveComponent _playerMoveComponent;

        public void FixedUpdate()
        {
            var direction = new Vector2(_inputSystem.HorizontalDirection, 0);
            _playerMoveComponent.MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
        }
    }
}