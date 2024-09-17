using Entities;
using UI;

namespace EventBus
{
	public struct HealRandomAllyEvent : ICombatEvent
	{
		public Entity Source;
        public int Amount;
	}
}