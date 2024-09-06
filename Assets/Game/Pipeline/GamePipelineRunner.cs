using Zenject;

namespace Lessons.Lesson19_EventBus
{
	public class GamePipelineRunner : IInitializable
	{
		private TurnPipeline[] _pipelines;
		private int _activeIndex = 0;

		[Inject]
		public GamePipelineRunner(TurnPipeline[] pipelines)
		{
			_pipelines = pipelines;
		}

		void IInitializable.Initialize()
		{
			for (var i = 0; i < _pipelines.Length; i++)
			{
				_pipelines[i].OnFinished += OnFinished;
			}
			Run();
		}

		private void OnFinished()
		{
			_pipelines[_activeIndex].Reset();
			int _activeIndex = _activeIndex == _pipelines.Length ? 0 : _activeIndex + 1;
			Run();
		}

		public void Run()
		{
			_pipelines[_activeIndex].RunNextTask();
		}
	}
}