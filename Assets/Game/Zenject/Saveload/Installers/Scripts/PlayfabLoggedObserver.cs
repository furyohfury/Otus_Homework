using System;
using PlayFabSystem;
using Zenject;

namespace SaveLoad
{
	public sealed class PlayfabLoggedObserver : IInitializable, IDisposable
	{
		private readonly SaveLoadManager _saveLoadManager;

		public PlayfabLoggedObserver(SaveLoadManager saveLoadManager)
		{
			_saveLoadManager = saveLoadManager;
		}

		public void Initialize()
		{
			PlayfabManager.OnLogged += OnLogged;
		}

		private void OnLogged()
		{
			_saveLoadManager.LoadSpecific<PlayfabLevelResultsSaveLoader>();
		}

		public void Dispose()
		{
			PlayfabManager.OnLogged -= OnLogged;
		}
	}
}