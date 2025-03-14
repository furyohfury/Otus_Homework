using Atomic.Entities;
using SaveLoad;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class LevelInstaller : MonoInstaller
	{

		public override void InstallBindings()
		{
			Container.Bind<FinishLine>()
			         .FromComponentInHierarchy()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<EnemyService>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<LevelTimer>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<LevelManager>()
			         .AsCached();

			Container.BindInterfacesAndSelfTo<Leaderboard>()
			         .AsCached();

			Container.BindInterfacesTo<LeaderboardSaveController>()
			         .AsCached();

			Container.Bind<IWinCondition>()
			         .To<EnemiesDeadWinCondition>()
			         .AsCached();
		}
	}
}