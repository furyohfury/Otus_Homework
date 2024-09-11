using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Entities
{
	public sealed class HeroEntity : Entity
	{
		[SerializeField]
		private HeroView _heroView;
		// [SerializeField]
		// private HeroConfig _config;
		[SerializeField, Space]
		private int _health;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private Team _team;
		[SerializeReference]
		private List<IComponent> _uniqueComponents;

		private void Awake()
		{
			AddData(new StatsComponent(_damage, _health, _health));
			AddData(new DestroyComponent());
			AddData(new HeroViewComponent(_heroView));
			AddData(new TeamComponent(_team));
			// AddData(_config.AttackEffects);
			foreach (var component in _uniqueComponents)
			{
				AddData(component);
			}

			var stats = $"{_damage}/{_health}";
			_heroView.SetStats(stats);
		}
	}
}