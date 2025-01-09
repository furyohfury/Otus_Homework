using Atomic.Entities;
using UI;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class LevelInstaller : MonoInstaller
	{
		[SerializeField]
		private SceneEntity[] _enemies;
		
		public override void InstallBindings()
		{
			Container.Bind<EnemiesDeadWinCondition>().AsCached();
			
			Container.Bind<FinishLine>().FromComponentInHierarchy().AsSingle();
			Container.Bind<EnemyService>().AsCached().WithArguments(_enemies);
			Container.Bind<LevelTimer>().AsCached();
			Container.BindInterfacesAndSelfTo<LevelTimerController>().AsCached();
			Container.BindInterfacesAndSelfTo<LevelManager>().AsCached();
			Container.BindInterfacesAndSelfTo<LeaderboardService>().AsCached();
		}
	}
}