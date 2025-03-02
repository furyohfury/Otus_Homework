using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	[Serializable]
	public sealed class JumpCommand : InputCommand
	{
		public override void Execute(IEntity entity)
		{
			if (entity.TryGetJumpRequest(out BaseEvent request))
			{
				request.Invoke();
			}
		}
	}
}