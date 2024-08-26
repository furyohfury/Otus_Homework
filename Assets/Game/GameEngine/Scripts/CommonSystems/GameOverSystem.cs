using Entitas;
using UnityEditor;

public sealed class GameOverSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _entities;

	public GameOverSystem(Contexts contexts)
	{
		var matcher = GameMatcher.AllOf(GameMatcher.DamagedEvent, GameMatcher.TypeId, GameMatcher.Inactive);
		_entities = contexts.game.GetGroup(matcher);
	}

	public void Execute()
	{
		foreach (var entity in _entities.GetEntities())
		{
			if (entity.typeId.Value == "Building")
			{
				EditorApplication.isPaused = true;
			}
		}
	}
}