using EventBus;

namespace Entities
{
	public sealed class PlayerComponent : IComponent
	{
		public Player Player;

		public PlayerComponent(Player player)
		{
			Player = player;
		}
	}
}