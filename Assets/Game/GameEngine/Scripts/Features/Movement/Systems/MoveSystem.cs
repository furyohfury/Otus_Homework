using Entitas;
using UnityEngine;

public sealed class MoveSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public MoveSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.MoveDirection,
			                         GameMatcher.MoveSpeed,
			                         GameMatcher.Position)
		                         .NoneOf(GameMatcher.Inactive,
			                         GameMatcher.DeathRequest);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		var deltaTime = Time.deltaTime;
		foreach (var entity in _entities.GetEntities())
		{
			entity.position.Value += entity.moveDirection.Value.normalized * entity.moveSpeed.Value * deltaTime;
		}
	}
}