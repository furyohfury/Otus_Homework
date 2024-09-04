using Lessons.Lesson19_EventBus.Visual;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class TurnPipelineInstaller : IInitializable
	{
		private readonly PlayerTurnPipeline _playerTurnPipeline;
		private readonly DiContainer _diContainer;

		[Inject]
		public TurnPipelineInstaller(PlayerTurnPipeline playerTurnPipeline, DiContainer diContainer)
		{
			_playerTurnPipeline = playerTurnPipeline;
			_diContainer = diContainer;
		}

		void IInitializable.Initialize()
		{
			_playerTurnPipeline.AddTask(new StartTask());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<PlayerInputTask>());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<StartVisualPipelineTask>());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<EnemyInputTask>());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<StartVisualPipelineTask>());
			_playerTurnPipeline.AddTask(new FinishTask());
		}
	}
}