using System.Collections.Generic;
using EventBus;
using UI;
using UnityEngine;

namespace Entities
{
	public sealed class HeroEntity : Entity
	{
		[SerializeField] [Space]
		private int _health;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private Player _player;
		
		[SerializeField] [Space]
		private HeroView _heroView;
		[SerializeField]
		private AudioClip[] _startTurnSounds;
		
		[SerializeReference]
		private List<IComponent> _uniqueComponents;

		private void Awake()
		{
			AddData(new StatsComponent(_damage, _health, _health));
			AddData(new DestroyComponent());
			AddData(new HeroViewComponent(_heroView));
			AddData(new PlayerComponent(_player));
			AddData(new HeroStartTurnSoundComponent(_startTurnSounds));
			
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