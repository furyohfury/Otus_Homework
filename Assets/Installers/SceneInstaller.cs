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

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60; // todo delete

            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterMoveController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<PlayerLookDirectionController>().AsSingle().WithArguments(_character);
            Container.BindInterfacesAndSelfTo<PlayerShootController>().AsSingle().WithArguments(_character);
        }
    }
}
