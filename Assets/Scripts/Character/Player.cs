using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent _hpComponent;
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private MoveComponent _moveComponent;

        private void OnValidate()
        {
            gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }
    }
}