using System.Collections.Generic;
using Entitas;
using UnityEngine;

// TODO mb make separate w/ movingevent (theres already a component)
public sealed class MovingAnimationSystem : ReactiveSystem<GameEntity>
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    public MovingAnimationSystem(IContext<GameEntity> context) : base(context)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveDirection.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMoveDirection && entity.hasAnimatorView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.animatorView.Value.SetBool(IsMoving, entity.hasMoveDirection); // TODO FIX LOL
        }
    }
}