using UnityEngine;
using Zenject;

namespace GameEngine.Installers
{
    public sealed class UnitsInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _unitsContainer;

        public override void InstallBindings()
        {
            var unitManager = new UnitManager(_unitsContainer);
            unitManager.SetupUnits(FindObjectsOfType<Unit>());
            Container.Bind<UnitManager>().FromInstance(unitManager);
        }
    }
}
