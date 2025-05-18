using Zenject;

namespace SaveLoad
{
	public sealed class LaunchSaveLoadersController : IInitializable
	{
		private readonly SaveLoadManager _saveLoadManager;

		[Inject]
		public LaunchSaveLoadersController(SaveLoadManager saveLoadManager)
		{
			_saveLoadManager = saveLoadManager;
		}

		public void Initialize()
		{
			_saveLoadManager.LoadSpecific<LevelResultsSaveLoader>();
		}
	}
}