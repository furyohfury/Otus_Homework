using System.Collections.Generic;
using Entitas;

// TODO mb make separate w/ movingevent (theres already a component). Then gotta redo target chase system as
// if (vectorToTarget.sqrMagnitude > entity.attackRange.Value * entity.attackRange.Value)
// {
// 	if (!entity.hasMoveDirection)
// 	{	
// 		entity.AddMoveDirection(vectorToTarget);
// 		entity.isMovingEvent = true;
// 	}
// 	entity.ReplaceMoveDirection(vectorToTarget);
// 	entity.isTargetInRange = false;
// 	continue;
// }
public sealed class AnimatorMovingListenerSystem : ReactiveSystem<GameEntity>
{
	public AnimatorMovingListenerSystem(IContext<GameEntity> context) : base(context)
	{
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.MoveDirection.AddedOrRemoved());
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAnimatorView;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			entity.animatorView.Value.SetBool(AnimatorHash.IsMoving, entity.hasMoveDirection);
		}
	}
}