namespace Entities
{
	public sealed class StatsComponent : IComponent // TODO mb unite with hp to stats component
	{
		public int Damage;
        public int CurrentHealth;
        public int MaxHealth;

		public DamageComponent(int damage, int currentHealth, int maxHealth)
		{
			Damage = damage;
            CurrentHealth = currentHealth;
			MaxHealth = maxHealth;
		}
	}
}