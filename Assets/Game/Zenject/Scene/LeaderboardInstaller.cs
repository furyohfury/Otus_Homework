using UnityEngine;
using Zenject;

namespace Game
{
	[CreateAssetMenu(fileName = "LeaderboardInstaller", menuName = "Create installer/LeaderboardInstaller")]
	public sealed class LeaderboardInstaller : ScriptableObjectInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<Leaderboard>()
			         .AsCached();
		}
	}
}