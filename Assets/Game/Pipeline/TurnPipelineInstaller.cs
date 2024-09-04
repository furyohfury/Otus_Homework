using Lessons.Lesson19_EventBus.Visual;
using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class TurnPipelineInstaller : IInitializable
	{
		private readonly TurnPipeline _turnPipeline;
		private readonly DiContainer _diContainer;

		[Inject]
		public TurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer diContainer)
		{
			_turnPipeline = turnPipeline;
			_diContainer = diContainer;
		}

		void IInitializable.Initialize()
		{
			_turnPipeline.AddTask(new StartTask());
			var playerInputTask = new PlayerInputTask();
			_diContainer.Inject(playerInputTask);
			_turnPipeline.AddTask(playerInputTask);
			// _turnPipeline.AddTask(_diContainer.CreateInstance<StartVisualPipelineTask>());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<EnemyInputTask>());
			// _turnPipeline.AddTask(_diContainer.CreateInstance<StartVisualPipelineTask>());
			_turnPipeline.AddTask(new FinishTask());
		}
	}
}