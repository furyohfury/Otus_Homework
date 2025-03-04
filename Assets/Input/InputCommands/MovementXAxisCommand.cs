using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class MovementXAxisCommand : InputCommand
	{
		public override void Execute(IEntity entity)
		{
			if (entity.TryGetMoveDirection(out ReactiveVariable<Vector2> moveDirection))
			{
				var currentDirection = moveDirection.Value;
				moveDirection.Value = new Vector2(AxisValue, currentDirection.y);
			}
		}
	}
}