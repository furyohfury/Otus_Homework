using Atomic.AI;
using Game.Content;

namespace Game.Engine
{
	public sealed class BarnBlackboardInstaller : BlackboardInstaller<Barn>
	{
		public override void Install(IBlackboard blackboard)
		{
			blackboard.SetObject(key, value.GetComponent<Barn>());
		}
	}
}