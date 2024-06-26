using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : Pool<Enemy>
    {
        public EnemyPool(Transform parent, Enemy prefab) : base(parent, prefab)
        {
        }
    }
}