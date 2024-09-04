using System;
using UI;
using UnityEngine;

namespace Entities
{
	public sealed class HeroEntity : Entity
	{
		[SerializeField]
		private HeroView _heroView;
		[SerializeField]
		private HeroConfig _config;

		private void Awake()
		{
			AddData(new HealthComponent(_config.CurrentHealth, _config.MaxHealth));
			AddData(new DamageComponent(_config.Damage));
			AddData(new DestroyComponent(gameObject));
			AddData(new HeroViewComponent(_heroView));
		}

		private void OnEnable()
		{
			var healthComponent = GetData<HealthComponent>();
			healthComponent.OnHealthChanged += ChangeViewHp;
		}

		private void ChangeViewHp(int hp)
		{
			
		}

		private void OnDisable()
		{
			var healthComponent = GetData<HealthComponent>();
			healthComponent.OnHealthChanged -= ChangeViewHp;
		}
	}
}