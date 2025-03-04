using Atomic.AI;
using Atomic.Entities;

namespace Game
{
	public sealed class TargetBlackboardInstaller : BlackboardInstaller<SceneEntity>
	{
		public override void Install(IBlackboard blackboard)
		{
			blackboard.SetObject(BlackboardAPI.Target, value);
		}
	}
}