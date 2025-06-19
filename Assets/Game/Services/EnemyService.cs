using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class EnemyService : IInitializable
	{
		public bool EnemiesDead => _enemies.Count <= 0;
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

		public IReadOnlyCollection<IEntity> GetEnemies(bool includeInactive)
		{
			if (includeInactive == false)
			{
				return _enemies.Where(enemy => SceneEntity.Cast(enemy).isActiveAndEnabled).ToArray();
			}

			return _enemies;
		}
		
		private void UpdateEnemies()
		{
			IReadOnlyList<IEntity> worldEnemies = _entityWorld.GetEntitiesWithTag(TagAPI.Enemy);
			_enemies = new HashSet<IEntity>(worldEnemies);
		}

		public void Reset()
		{
			UpdateEnemies();
		}
	}
}