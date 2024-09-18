using System;
using EventBus;

namespace Entities
{
	[Serializable]
	public sealed class PlayerComponent : IComponent
	{
		public Player Player;
	}
}