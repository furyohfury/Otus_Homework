namespace Entities
{
	public sealed class StatsComponent : IComponent
	{
		public int Damage;
        public int CurrentHealth;
        public int MaxHealth;

		public StatsComponent(int damage, int currentHealth, int maxHealth)
		{
			Damage = damage;
            CurrentHealth = currentHealth;
			MaxHealth = maxHealth;
		}
	}
}