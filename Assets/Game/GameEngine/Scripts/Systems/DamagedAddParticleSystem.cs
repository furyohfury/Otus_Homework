using Entitas;
using UnityEngine;

public class DamagedAddParticleSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;
	private readonly DamagedParticlesHelper _damagedParticlesHelper;

	public DamagedAddParticleSystem(Contexts contexts, DamagedParticlesHelper damagedParticlesHelper)
	{
		_damagedParticlesHelper = damagedParticlesHelper;
		_damagedParticlesHelper.Initialize();

		var matcher = GameMatcher.AllOf(
			                         GameMatcher.DamagedEvent,
			                         GameMatcher.TransformView,
			                         GameMatcher.TypeId,
			                         GameMatcher.Health)
		                         .NoneOf(GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			if (!_damagedParticlesHelper.HasId(entity.typeId.Value)) continue;

			var ratio = (float)entity.health.Current / entity.health.Max;
			// Can get w/ needed ratio from helper?
			if (!_damagedParticlesHelper.TryGetParticles(entity.typeId.Value, ratio, out var particleSystem))
			{
				continue;
			}

			// If has active system destroy it and replace with new
			if (entity.hasDamagedParticleSystem)
			{
				if (entity.damagedParticleSystem.Value.name == particleSystem.name) continue;
				Object.Destroy(entity.damagedParticleSystem.Value);
			}

			var goSystem = Object.Instantiate(particleSystem,
				entity.position.Value,
				Quaternion.identity,
				entity.transformView.Value);
			goSystem.name = particleSystem.name;
			entity.ReplaceDamagedParticleSystem(goSystem);
		}
	}
}