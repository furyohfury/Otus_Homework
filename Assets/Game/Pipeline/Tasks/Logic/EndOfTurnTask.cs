using Entities;
using Zenject;

namespace EventBus
{
	public sealed class EndOfTurnTask : EventTask
	{
		private readonly CurrentHeroService _currentHeroService;

		[Inject]
		public EndOfTurnTask(CurrentHeroService currentHeroService)
		{
			_currentHeroService = currentHeroService;
		}

		protected override void OnRun()
		{
			var currentHero = _currentHeroService.CurrentHero;
			currentHero.TryGetData(out HeroViewComponent heroViewComponent);
			heroViewComponent.HeroView.SetActive(false);
			Finish();
		}
	}
}