using Cysharp.Threading.Tasks;
using Zenject;

namespace Game
{
	public abstract class InputRebinder : IInitializable
	{
		private readonly IRebindSaveLoader _rebindSaveLoader;

		protected InputRebinder(IRebindSaveLoader rebindSaveLoader)
		{
			_rebindSaveLoader = rebindSaveLoader;
		}

		void IInitializable.Initialize()
		{
			_rebindSaveLoader.Load();
		}

		public async UniTask<string> MakeInteractiveRebind(string action, string oldPath)
		{
			var newPath = await Rebind(action, oldPath);
			_rebindSaveLoader.Save();
			return newPath;
		}

		public void RemoveRebind(string action, string defaultPath)
		{
			RemoveBindOverride(action, defaultPath);
			_rebindSaveLoader.Save();
		}

		protected abstract UniTask<string> Rebind(string action, string defaultPath);
		protected abstract void RemoveBindOverride(string action, string defaultPath);
	}
}