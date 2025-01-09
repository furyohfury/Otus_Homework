using Zenject;

namespace Game
{
	public sealed class EnemiesDeadWinCondition : IWinCondition
	{
		private readonly EnemyService _enemyService;

		[Inject]
		public EnemiesDeadWinCondition(EnemyService enemyService)
		{
			_enemyService = enemyService;
		}

		public bool IsMet => _enemyService.EnemiesDead;
	}
}