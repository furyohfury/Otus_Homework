using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour
    {

        [SerializeField] private HitPointsComponent _hpComponent; // мб лучше сделать свойствами и вместо прокидывания компонентов напрямую, прокидывать игрока.компонент?
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private MoveComponent _moveComponent;       

        private void OnValidate()
        {
            this.gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }
    }
}