using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using Zenject;

namespace Game
{
	public sealed class EnemyService : IInitializable, IDisposable
	{
		public bool EnemiesDead => _activeEnemies.Count <= 0;

		private readonly List<IEntity> _enemies;
		private HashSet<IEntity> _activeEnemies;

		[Inject]
		public EnemyService(IEnumerable<IEntity> enemies)
		{
			_enemies = enemies.ToList();
		}

		public void Initialize()
		{
			_activeEnemies = new HashSet<IEntity>(_enemies);
			foreach (var enemy in _enemies)
			{
				enemy.GetDeathEvent().Subscribe(() => _activeEnemies.Remove(enemy));
			}
		}

		public void Reset()
		{
			_activeEnemies.Clear();
			for (var i = 0; i < _enemies.Count; i++)
			{
				_activeEnemies.Add(_enemies[i]);
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