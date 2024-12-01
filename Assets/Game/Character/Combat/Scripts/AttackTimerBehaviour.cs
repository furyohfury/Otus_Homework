using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
	public sealed class AttackTimerBehaviour : IEntityInit
	{
		public void Init(IEntity entity)
		{
			var timer = new Timer();
			// timer.CurrentState
		}
	}
}