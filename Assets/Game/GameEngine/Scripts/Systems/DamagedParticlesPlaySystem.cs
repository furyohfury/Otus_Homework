using Entitas;
using UnityEngine;

public class DamagedParticlesPlaySystem : IExecuteSystem
{
	private IGroup<GameEntity> _entities;

	public DamagedParticlesPlaySystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.DamagedParticleSystem);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var system = entity.damagedParticleSystem.Value;
			if (!system.isPlaying)
			{
				system.Play();
				// if (!system.main.loop)
				// {
				// 	Object.Destroy(system.gameObject, system.main.duration);
				// }
			}
		}
	}
}