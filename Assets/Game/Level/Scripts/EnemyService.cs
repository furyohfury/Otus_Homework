using System;
using System.Collections.Generic;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class EnemyService : IInitializable, IDisposable
	{
		public bool EnemiesDead => _activeEnemies.Count <= 0;

		private HashSet<IEntity> _enemies;
		private HashSet<IEntity> _activeEnemies;
		private readonly IEntityWorld _entityWorld;

		[Inject]
		public EnemyService(IEntityWorld entityWorld)
		{
			_entityWorld = entityWorld;
		}

		public void Initialize()
		{
			var worldEnemies = _entityWorld.GetEntitiesWithTag(TagAPI.Enemy);
			_enemies = new HashSet<IEntity>(worldEnemies);
			_activeEnemies = new HashSet<IEntity>(_enemies);
			foreach (var enemy in _enemies)
			{
				enemy.GetDeathEvent().Subscribe(() => _activeEnemies.Remove(enemy));
			}
		}

		public void Reset()
		{
			_activeEnemies.Clear();

			foreach (var enemy in _enemies)
			{
				_activeEnemies.Add(enemy);
			}
		}

		public void Dispose()
		{
			foreach (var enemy in _enemies)
			{
				enemy.GetDeathEvent().Unsubscribe(() => _activeEnemies.Remove(enemy));
			}
		}
	}
}