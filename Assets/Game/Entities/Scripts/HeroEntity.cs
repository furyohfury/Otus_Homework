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
		[SerializeField]
		private Team _team;

		private void Awake()
		{
			AddData(new HealthComponent(_config.CurrentHealth, _config.MaxHealth));
			AddData(new DamageComponent(_config.Damage));
			AddData(new DestroyComponent());
			AddData(new HeroViewComponent(_heroView));
			AddData(new TeamComponent(_team));
			AddData(_config.AttackEffects);
		}

		private void OnEnable()
		{
			var healthComponent = GetData<HealthComponent>();
			healthComponent.OnHealthChanged += ChangeViewHp;
		}

		private void ChangeViewHp(int hp)
		{
			var damageComponent = GetData<DamageComponent>();
			int damage = damageComponent.Damage;
			_heroView.SetStats($"{damage}/{hp}");
		}

		private void OnDisable()
		{
			var healthComponent = GetData<HealthComponent>();
			healthComponent.OnHealthChanged -= ChangeViewHp;
		}
	}
}