using Game;

namespace UI
{
	public sealed class EnemyCountUIController : IGameTickable
	{
		private readonly AmountView _amountView;
		private readonly EnemyService _enemyService;

		public EnemyCountUIController(AmountView amountView, EnemyService enemyService)
		{
			_amountView = amountView;
			_enemyService = enemyService;
		}

		public void Tick(float deltaTime)
		{
			var enemiesCount = _enemyService.Enemies.Count;
			_amountView.SetText(enemiesCount.ToString());
		}
	}
}