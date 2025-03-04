using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	[Serializable]
	public sealed class AttackCommand : InputCommand
	{
		public override void Execute(IEntity entity)
		{
			if (entity.TryGetAttackRequest(out BaseEvent request))
			{
				request.Invoke();
			}
		}
	}
}