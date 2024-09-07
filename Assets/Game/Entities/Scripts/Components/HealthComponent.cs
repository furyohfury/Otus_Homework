using System;
using UniRx;

namespace Entities
{
	public sealed class HealthComponent : IComponent
	{
		public Action<int> OnHealthChanged;
		public int CurrentHealth;
		public int MaxHealth;

		public HealthComponent(int currentHealth, int maxHealth)
		{
			CurrentHealth = currentHealth;
			MaxHealth = maxHealth;
		}

		public void ChangeCurrentHealth(int hp)
		{
			CurrentHealth += hp;
			OnHealthChanged?.Invoke(CurrentHealth);
		}
		
		public void ChangeMaxHealth(int hp)
		{
			MaxHealth = hp;
		}
	}
}