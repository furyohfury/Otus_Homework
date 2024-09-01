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
		private Entity _entity;

		private void Awake()
		{
			_entity.AddData(new HealthComponent(_config.CurrentHealth, _config.MaxHealth));
		}

		private void OnEnable()
		{
			var healthComponent = GetData<HealthComponent>();
			// healthComponent.CurrentHealth.Subscribe(_heroView.SetStats(c));
		}

		private void ChangeViewHp(int hp)
		{
			
		}

		private void OnDisable()
		{
			
		}
	}
}