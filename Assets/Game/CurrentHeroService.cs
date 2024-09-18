using Entities;

namespace EventBus
{
	public sealed class CurrentHeroService
	{
		public HeroEntity CurrentHero { get; private set; }
		public Player CurrentPlayer { get; private set; }

		public void SetCurrentHero(HeroEntity heroEntity)
		{
			CurrentHero = heroEntity;
		}

		public void SetCurrentPlayer(Player player)
		{
			CurrentPlayer = player;
		}
	}
}