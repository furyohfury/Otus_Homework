using Entitas;

public sealed class TargetDetectionSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _searchGroup;
	private readonly IGroup<GameEntity> _targetGroup;

	public TargetDetectionSystem(Contexts contexts)
	{
		var seekerMatcher = GameMatcher.AllOf(GameMatcher.TargetSearchRequest,
			GameMatcher.Team,
			GameMatcher.AttackRange,
			GameMatcher.Position);
		_searchGroup = contexts.game.GetGroup(seekerMatcher);
		var targetMatcher = GameMatcher.AllOf(GameMatcher.Team, GameMatcher.Position)
		                               .NoneOf(GameMatcher.Inactive);
		_targetGroup = contexts.game.GetGroup(targetMatcher);
	}

	public void Execute()
	{
		foreach (var entity in _searchGroup.GetEntities())
		{
			GameEntity target = null;
			var minDistance = float.MaxValue;
			foreach (var ent in _targetGroup.GetEntities())
			{
				if (ent == entity || ent.team.Value == entity.team.Value) continue;

				var entPos = ent.position.Value;
				var distance = (entPos - entity.position.Value).sqrMagnitude;

				if (distance < minDistance)
				{
					minDistance = distance;
					target = ent;
				}
			}

			if (target != null)
			{
				entity.AddEnemyTarget(target);
			}

			entity.isTargetSearchRequest = false;
		}
	}
}