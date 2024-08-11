using Atomic.Objects;
using GameEngine;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
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
        [SerializeField]
        private GameObject _gameOverPopup;

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraComponent>().AsSingle().WithArguments(_character.transform);
            Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<CharacterLookDirectionController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<CharacterShootController>().AsSingle().WithArguments(_character);
            Container.Bind<GameManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverController>().AsSingle().WithArguments(_character, _gameOverPopup);
            var zombieSpawner = new SpawnerOnCD(_zombieSpawnCD, _zombiePrefab, _worldTransform, _zombieSpawnPoints);
            Container.Bind<SpawnerOnCD>().FromInstance(zombieSpawner).AsCached();
            Container.BindInterfacesAndSelfTo<EnemySystem>().AsCached().WithArguments(_zombieDestroyDelay);
        }
    }
}
