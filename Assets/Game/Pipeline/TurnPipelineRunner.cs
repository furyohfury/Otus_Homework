using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class TurnPipelineRunner : IInitializable
	{
		private readonly TurnPipeline _pipeline;

		[Inject]
		public TurnPipelineRunner(TurnPipeline pipeline)
		{
			_pipeline = pipeline;
		}

		void IInitializable.Initialize()
		{
			_pipeline.OnFinished += OnFinished;
			// Run(); // TODO uncomm
		}

		private void OnFinished()
		{
			_pipeline.Reset();
			_pipeline.RunNextTask();
		}

		public void Run()
		{
			_pipeline.RunNextTask();
		}
	}
}