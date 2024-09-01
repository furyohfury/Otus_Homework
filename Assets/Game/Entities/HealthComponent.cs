using System;
using UniRx;

namespace Entities
{
	public sealed class HealthComponent : IComponent
	{
		public readonly ReactiveProperty<int> CurrentHealth = new();
		public readonly ReactiveProperty<int> MaxHealth = new();

		public HealthComponent(int currentHealth, int maxHealth)
		{
			CurrentHealth.Value = currentHealth;
			MaxHealth.Value = maxHealth;
		}

		// public void ChangeCurrentHealth(int hp)
		// {
		// 	CurrentHealth = hp;
		// 	OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
		// }
		//
		// public void ChangeMaxHealth(int hp)
		// {
		// 	MaxHealth = hp;
		// 	OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
		// }
	}
}