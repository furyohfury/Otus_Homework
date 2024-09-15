using EventBus.Visual;
using Zenject;

namespace EventBus
{
	public class AITurnPipelineInstaller : IInitializable
	{
		private readonly TurnPipeline _turnPipeline;
		private readonly DiContainer _diContainer;

		[Inject]
		public AITurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer diContainer)
		{
			_turnPipeline = turnPipeline;
			_diContainer = diContainer;
		}

		void IInitializable.Initialize()
		{			
			_turnPipeline.AddTask(new StartTask());
			_turnPipeline.AddTask(_diContainer.Instantiate<StartTurnTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<AIInputTask>());		
			// endturntask
			_turnPipeline.AddTask(_diContainer.Instantiate<StartVisualPipelineTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<EndOfTurnTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<StartVisualPipelineTask>());
			_turnPipeline.AddTask(new FinishTask());
		}
	}
}