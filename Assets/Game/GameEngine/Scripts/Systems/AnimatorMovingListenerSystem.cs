using System.Collections.Generic;
using Entitas;

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