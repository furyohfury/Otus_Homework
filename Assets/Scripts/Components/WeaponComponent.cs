using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public sealed class WeaponComponent
    {
        [SerializeField] private Transform firePoint;

        public Vector2 Position => firePoint.position;

        public Quaternion Rotation => firePoint.rotation;
    }
}