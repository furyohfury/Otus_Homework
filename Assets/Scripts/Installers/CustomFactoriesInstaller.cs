using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CustomFactoriesInstaller : MonoInstaller
    {
        private const string ENEMY_RESPAWN_POSITIONS_TAG = "Respawn";
        private const string ENEMY_ATTACK_POSITION_TAG = "AttackPosition";
        [SerializeField] private int _initialBulletPoolCount;
        [SerializeField] private int _initialEnemyPoolCount;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolsParent;

        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _enemyTarget;

        public override void InstallBindings()
        {
            var bulletFactory = new BulletFactory(_worldTransform, _poolsParent, _bulletPrefab, _initialBulletPoolCount);
            Container.Bind<BulletFactory>().FromInstance(bulletFactory).AsSingle();

            var enemySpawnPositionsGO = GameObject.FindGameObjectsWithTag(ENEMY_RESPAWN_POSITIONS_TAG);
            var enemySpawnPositionsTransform = enemySpawnPositionsGO.Select((pos) => pos.transform).ToArray();
            var enemyAttackPositionsGO = GameObject.FindGameObjectsWithTag(ENEMY_ATTACK_POSITION_TAG);
            var enemyAttackPositionsTransform = enemyAttackPositionsGO.Select((pos) => pos.transform).ToArray();
            EnemyPositions enemyPositions = new(enemySpawnPositionsTransform, enemyAttackPositionsTransform);
            var enemyFactory = new EnemyFactory(_initialEnemyPoolCount, enemyPositions, _enemyTarget, _worldTransform, _poolsParent, _enemyPrefab);
            Container.Bind<EnemyFactory>().FromInstance(enemyFactory).AsSingle();
        }
    }
}