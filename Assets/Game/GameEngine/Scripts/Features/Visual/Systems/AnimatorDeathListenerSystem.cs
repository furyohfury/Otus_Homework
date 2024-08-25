using Entitas;
using UnityEngine;

public class AnimatorDeathListenerSystem : IExecuteSystem, ICleanupSystem
{
	private readonly IGroup<GameEntity> _entities;

	public AnimatorDeathListenerSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.DeathEvent, GameMatcher.AnimatorView);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			var animator = entity.animatorView.Value;
			animator.SetTrigger(AnimatorHash.Death);
			entity.isDelayedDeath = true;
		}
	}

	public void Cleanup()
	{
		foreach (var entity in _entities.GetEntities())
		{
			entity.isDeathEvent = false;
		}
	}
}