using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public sealed class WeaponComponent
    {
        [SerializeField] private Transform firePoint;

        public Vector2 Position
        {
            get { return firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return firePoint.rotation; }
        }
    }
}