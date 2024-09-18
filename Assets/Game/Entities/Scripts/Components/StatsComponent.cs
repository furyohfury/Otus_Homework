using System;

namespace Entities
{
	[Serializable]
	public sealed class StatsComponent : IComponent
	{
		public int Damage;
		public int CurrentHealth;
		public int MaxHealth;
	}
}