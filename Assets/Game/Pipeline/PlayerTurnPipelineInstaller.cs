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
			_turnPipeline.AddTask(_diContainer.Instantiate<StartTurnTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<PlayerInputTask>());		
			// endturntask
			_turnPipeline.AddTask(_diContainer.Instantiate<StartVisualPipelineTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<EndOfTurnTask>());
			_turnPipeline.AddTask(_diContainer.Instantiate<StartVisualPipelineTask>());
			_turnPipeline.AddTask(new FinishTask());
		}
	}
}