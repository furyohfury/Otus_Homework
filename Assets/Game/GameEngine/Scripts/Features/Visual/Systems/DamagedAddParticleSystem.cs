using Entitas;
using UnityEngine;

public class DamagedAddParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly DamagedParticlesHelper _damagedParticlesHelper;
	private readonly EntityManager _entityManager;

	public DamagedAddParticleSystem(Contexts contexts, DamagedParticlesHelper damagedParticlesHelper,
		EntityManager entityManager)
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
			// Can get ParticleSystem with needed ratio from helper?
			if (!_damagedParticlesHelper.TryGetParticles(entity.typeId.Value, ratio, out var particleSystem))
			{
				continue;
			}

			Transform parent = null;
			if (ratio != 0)
			{
				parent = entity.transformView.Value;
			}
			// If already has ParticleSystem than need to replace it and destroy old one
			if (entity.hasDamagedParticleSystem)
			{
				var existingSystem = entity.damagedParticleSystem.Value;
				if (existingSystem.name == particleSystem.name)
				{
					continue;
				}

				existingSystem.Stop();
				_entityManager.DestroyNonEntity(existingSystem);
			}

			var goSystem = SpawnSystem(particleSystem, entity, parent);
			entity.ReplaceDamagedParticleSystem(goSystem);
			entity.isDamagedParticleSystemRequest = true;
		}
	}

	private ParticleSystem SpawnSystem(ParticleSystem particleSystem, GameEntity entity, Transform parent)
	{
		var goSystem = _entityManager.CreateNonEntity(particleSystem,
			entity.position.Value,
			entity.rotation.Value,
			parent);
		goSystem.name = particleSystem.name;
		return goSystem;
	}
}