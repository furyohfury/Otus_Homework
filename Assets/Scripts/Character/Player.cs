using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour
    {

        [SerializeField] private HitPointsComponent _hpComponent; 
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private MoveComponent _moveComponent;
        // мб лучше сделать свойствами и вместо прокидывания компонентов напрямую, прокидывать игрока.компонент?
        // хотя вроде и так норм но тогда вообще можно поля убрать

        private void OnValidate()
        {
            gameObject.layer = (int)PhysicsLayer.CHARACTER;
        }
    }
}