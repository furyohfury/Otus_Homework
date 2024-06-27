using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : Pool<Bullet>
    {
        public BulletPool(Transform parent, Bullet prefab) : base(parent, prefab) { }
    }
}
