using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;

        public Vector2 GetRandomSpawnPosition()
        {
            return RandomTransform(spawnPositions).position;
        }

        public Vector2 GetRandomAttackPosition()
        {
            return RandomTransform(attackPositions).position;
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}