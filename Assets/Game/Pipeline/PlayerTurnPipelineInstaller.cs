using EventBus.Visual;
using Zenject;

namespace EventBus
{
	public class PlayerTurnPipelineInstaller : IInitializable
	{
		private readonly TurnPipeline _turnPipeline;
		private readonly DiContainer _diContainer;

		[Inject]
		public PlayerTurnPipelineInstaller(TurnPipeline turnPipeline, DiContainer diContainer)
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
			var startVisualPipelineTask = new StartVisualPipelineTask();
			// endturntask
			_diContainer.Inject(startVisualPipelineTask);
			_turnPipeline.AddTask(startVisualPipelineTask);
			
			_turnPipeline.AddTask(new FinishTask());
		}
	}
}