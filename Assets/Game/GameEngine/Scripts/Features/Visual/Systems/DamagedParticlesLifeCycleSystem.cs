﻿using Entitas;

public class DamagedParticlesLifeCycleSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly EntityManager _entityManager;

	public DamagedParticlesLifeCycleSystem(Contexts contexts, EntityManager entityManager)
	{
		_entityManager = entityManager;
		var matcher = GameMatcher.AllOf(GameMatcher.DamagedParticleSystem, GameMatcher.DamagedParticleSystemRequest);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.damagedParticleSystem.Value.Play();
			entity.isDamagedParticleSystemRequest = false;
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			if (!entity.damagedParticleSystem.Value.IsAlive())
			{
				_entityManager.DestroyNonEntity(entity.damagedParticleSystem.Value);
				entity.RemoveDamagedParticleSystem();
			}
		}
	}
}