using System;
using Atomic.Entities;

namespace Game
{
	[Serializable]
	public sealed class PauseCommand : InputCommand
	{
		public override void Execute(IEntity entity)
		{
		}
	}
}