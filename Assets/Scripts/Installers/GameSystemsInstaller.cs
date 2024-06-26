using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class GameSystemsInstaller : MonoInstaller
    {
        [SerializeField] private float _gameStartCountdown = 3f;

        [SerializeField] private int _maxEnemiesCount = 7;
        [SerializeField] private float _enemiesSpawnInterval = 1f;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerFireController>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsCached().NonLazy();

            Container.BindInterfacesAndSelfTo<InputListener>().AsCached();

            Container.BindInterfacesAndSelfTo<BulletSystem>().AsCached();
            Container.BindInterfacesAndSelfTo<BulletsOutOfBoundsObserver>().AsCached().NonLazy();

            Container.Bind<EnemySystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyCycleSpawner>().AsSingle().WithArguments(_enemiesSpawnInterval, _maxEnemiesCount).NonLazy();

            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLauncher>().AsCached().WithArguments(_gameStartCountdown).NonLazy();
            Container.BindInterfacesAndSelfTo<GamePauseObserver>().AsCached();
        }
    }
}
