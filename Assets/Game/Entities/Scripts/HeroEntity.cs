using System.Collections.Generic;
using EventBus;
using UI;
using UnityEngine;

namespace Entities
{
	public sealed class HeroEntity : Entity
	{
		[SerializeField]
		private StatsComponent _stats;
		[SerializeField]
		private PlayerComponent _player;
		
		[SerializeField] [Space]
		private HeroViewComponent _heroView;
		[SerializeField]
		private HeroSoundComponent _sounds;
		
		[SerializeReference]
		private List<IComponent> _uniqueComponents;

		private void Awake()
		{
			InitializeData();

			var stats = $"{_stats.Damage}/{_stats.Health}";
			_heroView.HeroView.SetStats(stats);
		}

		private void InitializeData()
		{
			AddData(_stats);			
			AddData(_heroView);
			AddData(_player);
			AddData(_sounds);
			AddData(new DestroyComponent());
			
			foreach (var component in _uniqueComponents)
			{
				AddData(component);
			}
		}

		private void OnValidate()
		{
			_heroView.HeroView.SetStats(stats);
		}
	}
}