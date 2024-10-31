using Atomic.AI;
using Game.Content;

namespace Game.Engine
{
	public sealed class CharacterBlackBoardInstaller : BlackboardInstaller<Character>
	{
		public override void Install(IBlackboard blackboard)
		{
			blackboard.SetObject(key, value.GetComponent<Character>());
		}
	}
}