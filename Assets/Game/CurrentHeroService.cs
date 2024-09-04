using System;
using Entities;
using Lessons.Lesson19_EventBus;
using Zenject;

public sealed class CurrentHeroService : ICurrentHeroService, IInitializable, IDisposable // TODO make everything through interface
{
	public HeroEntity CurrentHero => _currentHero;
	public HeroEntity _currentHero; // TODO make private after debug
	private TurnPipelineRunner _pipelineRunner;

	public CurrentHeroService(TurnPipelineRunner pipelineRunner)
	{
		_pipelineRunner = pipelineRunner;
	}

	public void Initialize()
	{
		// _pipelineRunner.OnPipelineCompleted += OnPipelineCompleted;
	}

	public void OnPipelineCompleted()
	{
	}

	public void Dispose()
	{
		// _pipelineRunner.OnPipelineCompleted -= OnPipelineCompleted;
	}
}