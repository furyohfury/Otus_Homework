using Entitas;
using UnityEngine;

public class DamagedAddParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly DamagedParticlesHelper _damagedParticlesHelper;
	private EntityManager _entityManager;

	public DamagedAddParticleSystem(Contexts contexts, DamagedParticlesHelper damagedParticlesHelper, EntityManager entityManager)
	{
		_damagedParticlesHelper = damagedParticlesHelper;
		_entityManager = entityManager;
		_damagedParticlesHelper.Initialize();

		var matcher = GameMatcher.AllOf(
			                         GameMatcher.DamagedEvent,
			                         GameMatcher.TransformView,
			                         GameMatcher.TypeId,
			                         GameMatcher.Health);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute() // Мне не нравится, но я уже слишком долго над этим сидел, пытаясь сделать нормально))
	{
		foreach (var entity in _entities.GetEntities())
		{
			var ratio = (float)entity.health.Current / entity.health.Max;
			// Can get PS w/ needed ratio from helper?
			if (!_damagedParticlesHelper.TryGetParticles(entity.typeId.Value, ratio, out var particleSystem))
			{
				continue;
			}

			if (!particleSystem.main.loop)
			{
				SpawnSystem(particleSystem, entity);
			}
			else if (entity.hasDamagedParticleSystem)
			{
				var existingSystem = entity.damagedParticleSystem.Value;
				if (existingSystem.name == particleSystem.name)
				{
					continue;
				}

				existingSystem.Stop();
				_entityManager.DestroyNonEntity(existingSystem);
			}
			var goSystem = SpawnSystem(particleSystem, entity);
			entity.ReplaceDamagedParticleSystem(goSystem);
			entity.isDamagedParticleSystemRequest = true;
		}
	}

	private ParticleSystem SpawnSystem(ParticleSystem particleSystem, GameEntity entity)
	{
		var goSystem = _entityManager.CreateNonEntity(particleSystem,
			entity.position.Value,
			entity.direction.Value,
			entity.transformView.Value);
		goSystem.name = particleSystem.name;
		return goSystem;
	}
}