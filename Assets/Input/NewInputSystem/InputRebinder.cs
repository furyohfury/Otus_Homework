using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;

namespace Game
{
	public abstract class InputRebinder
	{
		public abstract UniTask<string> MakeInteractiveRebind(string action, string oldPath);
	}
}