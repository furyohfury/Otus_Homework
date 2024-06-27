using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions
    {
        private readonly Transform[] _spawnPositions;

        private readonly Transform[] _attackPositions;

        public EnemyPositions(Transform[] spawnPositions, Transform[] attackPositions)
        {
            _spawnPositions = spawnPositions;
            _attackPositions = attackPositions;
        }

        public Vector2 GetRandomSpawnPosition() => RandomTransform(_spawnPositions).position;

        public Vector2 GetRandomAttackPosition() => RandomTransform(_attackPositions).position;

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}