using System;
using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class EnemyService : IInitializable, IDisposable
	{
		public bool EnemiesDead => _enemies.Count <= 0;
		public IReadOnlyCollection<IEntity> Enemies => _enemies;
		public Transform Container => _container;

		private HashSet<IEntity> _enemies;
		private readonly IEntityWorld _entityWorld;
		private readonly Transform _container;

		[Inject]
		public EnemyService(IEntityWorld entityWorld, Transform container)
		{
			_entityWorld = entityWorld;
			_container = container;
		}

		public void Initialize()
		{
			UpdateEnemies();
		}

		private void UpdateEnemies()
		{
			IReadOnlyList<IEntity> worldEnemies = _entityWorld.GetEntitiesWithTag(TagAPI.Enemy);
			_enemies = new HashSet<IEntity>(worldEnemies);
			foreach (var enemy in _enemies)
			{
				if (enemy.TryGetDeathEvent(out var deathEvent))
				{
					deathEvent.Subscribe(() => _enemies.Remove(enemy));
				}
			}
		}

		public void Reset()
		{
			UpdateEnemies();
		}

		public void Dispose()
		{
			if (_enemies == null)
			{
				return;
			}

			foreach (var enemy in _enemies)
			{
				if (enemy.TryGetDeathEvent(out var deathEvent))
				{
					deathEvent.Unsubscribe(() => _enemies.Remove(enemy));
				}
			}
		}
	}
}