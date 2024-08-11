using Atomic.Objects;
using GameEngine;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        //[SerializeField]
        //private Transform _player;
        [SerializeField]
        private AtomicObject _character;
        [SerializeField]
        private AtomicObject _zombiePrefab;
        [SerializeField]
        private float _zombieSpawnCD = 2f;
        [SerializeField]
        private Transform _worldTransform;
        [SerializeField]
        private Transform[] _zombieSpawnPoints;
        [SerializeField]
        private float _zombieDestroyDelay = 2f;

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60; // todo delete

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<PlayerLookDirectionController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<PlayerShootController>().AsSingle().WithArguments(_character);
            Container.Bind<GameManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsSingle().WithArguments(_character);
            var zombieSpawner = new SpawnerOnCD(_zombieSpawnCD, _zombiePrefab, _worldTransform, _zombieSpawnPoints);
            Container.BindInterfacesAndSelfTo<SpawnerOnCD>().FromInstance(zombieSpawner).AsCached();
            Container.Bind<EnemySystem>().AsCached().WithArguments(_zombieDestroyDelay);
        }
    }
}
