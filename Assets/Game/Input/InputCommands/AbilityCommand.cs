using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	[Serializable]
	public sealed class AbilityCommand : InputCommand
	{
		public override void Execute(IEntity entity)
		{
			if (entity.TryGetAbilityRequest(out BaseEvent request))
			{
				request.Invoke();
			}
		}
	}
}