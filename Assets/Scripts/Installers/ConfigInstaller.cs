using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/Config installer")]
    public class ConfigInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BulletConfig _enemyBulletConfig;
        [SerializeField] private BulletConfig _playerBulletConfig;
        [SerializeField] private BackgroundConfig _backgroundConfig;

        public override void InstallBindings()
        {
            Container.Bind<BulletConfig>().FromInstance(_enemyBulletConfig).AsCached().WhenInjectedInto<EnemyAttackAgent>();
            Container.Bind<BulletConfig>().FromInstance(_playerBulletConfig).AsCached().WhenInjectedInto<PlayerFireController>();
            Container.Bind<BackgroundConfig>().FromInstance(_backgroundConfig).AsSingle();
        }
    }
}
