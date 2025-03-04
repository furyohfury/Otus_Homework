using Atomic.AI;
using Atomic.Entities;

namespace Game
{
	public sealed class EntityBlackboardInstaller : BlackboardInstaller<SceneEntity>
	{
		public override void Install(IBlackboard blackboard)
		{
			blackboard.SetObject(BlackboardAPI.Entity, value);
		}
	}
}