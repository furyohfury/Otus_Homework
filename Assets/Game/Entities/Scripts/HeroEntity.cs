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
			AddData(new StatsComponent(_config.Damage, _config.Health, _config.Health));
			AddData(new DestroyComponent());
			AddData(new HeroViewComponent(_heroView));
			AddData(new TeamComponent(_team));
			AddData(_config.AttackEffects);
		}
	}
}