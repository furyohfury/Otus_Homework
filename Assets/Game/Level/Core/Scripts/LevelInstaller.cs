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

			Container.BindInterfacesAndSelfTo<LevelTimer>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<LevelManager>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<Leaderboard>()
			         .AsSingle();

			Container.BindInterfacesTo<LeaderboardSaveController>()
			         .AsCached();

			Container.Bind<IWinCondition>()
			         .To<EnemiesDeadWinCondition>()
			         .AsCached();
		}
	}
}