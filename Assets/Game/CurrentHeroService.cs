using System;
using Entities;
using Lessons.Lesson19_EventBus;
using Zenject;

public sealed class CurrentHeroService : ICurrentHeroService, IInitializable, IDisposable // TODO make everything through interface
{
	public HeroEntity CurrentHero => _currentHero;
	private HeroEntity _currentHero;

	public CurrentHeroService()
	{
		
	}

	public void Initialize()
	{
		
	}

	public void SetCurrentHero(HeroEntity heroEntity) => _currentHero = heroEntity;

	public void Dispose()
	{
		
	}
}