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
             var aiInputTask = _diContainer.Instantiate<AIInputTask>();
			_turnPipeline.AddTask(aiInputTask);			
			var startVisualPipelineTask = new StartVisualPipelineTask();
			// endturntask
			_diContainer.Inject(startVisualPipelineTask);
			_turnPipeline.AddTask(startVisualPipelineTask);
			
			_turnPipeline.AddTask(new FinishTask());
		}
	}
}