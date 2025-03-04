using Atomic.Entities;

namespace Game
{
	public abstract class InputCommand
	{
		public float AxisValue;

		public abstract void Execute(IEntity entity);
	}
}