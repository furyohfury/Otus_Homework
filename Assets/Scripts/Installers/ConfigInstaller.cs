using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/Config installer")]
    public class ConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BulletConfig _enemyBulletConfig;
        [SerializeField] private BulletConfig _playerBulletConfig;

        public override void InstallBindings()
        {
            Container.Bind<BulletConfig>().FromInstance(_enemyBulletConfig).AsSingle().WhenInjectedInto<EnemyAttackAgent>();
            Container.Bind<BulletConfig>().FromInstance(_playerBulletConfig).AsSingle().WhenInjectedInto<PlayerFireController>();
        }

    }
}
