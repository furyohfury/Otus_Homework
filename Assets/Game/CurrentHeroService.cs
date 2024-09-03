public sealed class CurrentHeroService : ICurrentHeroService, IInitializable, IDisposable
{
    public HeroEntity CurrentHero {get; private set;}
    private PipelineRunenr _pipelineRunner;

    public CurrentHeroService(PipelineRunner pipelineRunner)
    {
        _pipelineRunner = pipelineRunner;
    }

    public void Initialize()
    {
        _pipelineRunner.OnPipelineCompleted += OnPipelineCompleted;
    }

    public void OnPipelineCompleted()
    {
        
    }

    public void Dispose()
    {
        _pipelineRunner.OnPipelineCompleted -= OnPipelineCompleted;
    }
}

public interface ICurrentHeroService
{
    public HeroEntity CurrentHero {get;}
}