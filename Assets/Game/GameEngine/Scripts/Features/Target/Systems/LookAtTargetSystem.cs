using Entitas;
using UnityEngine;

public sealed class LookAtTargetSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public LookAtTargetSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.Rotation,
			GameMatcher.EnemyTarget,
			GameMatcher.Position,
			GameMatcher.RotationRate);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		var deltaTime = Time.deltaTime;
		foreach (var entity in _entities.GetEntities())
		{
			var enemyTarget = entity.enemyTarget.Value;
			var lookRot = Quaternion.LookRotation(enemyTarget.position.Value - entity.position.Value);
			entity.rotation.Value =
				Quaternion.Slerp(entity.rotation.Value, lookRot, deltaTime * entity.rotationRate.Value);
		}
	}
}