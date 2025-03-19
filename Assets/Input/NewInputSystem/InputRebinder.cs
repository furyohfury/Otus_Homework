using Cysharp.Threading.Tasks;

namespace Game
{
	public abstract class InputRebinder
	{
		private readonly IRebindSaveLoader _rebindSaveLoader;

		protected InputRebinder(IRebindSaveLoader rebindSaveLoader)
		{
			_rebindSaveLoader = rebindSaveLoader;
		}

		public async UniTask<string> MakeInteractiveRebind(string action, string oldPath)
		{
			var newPath = await Rebind(action, oldPath);
			_rebindSaveLoader.Save();
			return newPath;
		}

		protected abstract UniTask<string> Rebind(string action, string oldPath);
	}
}