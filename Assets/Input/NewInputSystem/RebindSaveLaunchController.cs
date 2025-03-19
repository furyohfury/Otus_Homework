using Zenject;

namespace Game
{
	public sealed class RebindSaveLaunchController : IInitializable
	{
		private readonly IRebindSaveLoader _rebindSaveLoader;

		public RebindSaveLaunchController(IRebindSaveLoader rebindSaveLoader)
		{
			_rebindSaveLoader = rebindSaveLoader;
		}

		void IInitializable.Initialize()
		{
			_rebindSaveLoader.Load();
		}
	}
}