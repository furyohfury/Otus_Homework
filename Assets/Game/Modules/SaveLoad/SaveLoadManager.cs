using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace SaveLoad
{
	public sealed class SaveLoadManager : IInitializable, IDisposable
	{
		private readonly ISaveLoader[] _saveLoaders;
		private readonly IGameRepository _repository;
		private DiContainer _diContainer;

		public SaveLoadManager(ISaveLoader[] saveLoaders, IGameRepository repository, DiContainer diContainer)
		{
			_saveLoaders = saveLoaders;
			_repository = repository;
			_diContainer = diContainer;
		}

		public void Initialize()
		{
			UpdateContainer();
			_repository.LoadState();
			SceneManager.activeSceneChanged += OnSceneChanged;
		}

		[Button]
		public void Load()
		{
			_repository.LoadState();

			foreach (var saveLoader in _saveLoaders)
			{
				saveLoader.LoadGame(_repository, _diContainer);
			}
#if UNITY_EDITOR
			Debug.Log("State loaded by SaveLoadManager");
#endif
		}

		public void LoadSpecific<T>() where T : ISaveLoader
		{
			var saveLoaders = _saveLoaders.OfType<T>();
			foreach (var saveLoader in saveLoaders)
			{
				saveLoader.LoadGame(_repository, _diContainer);
			}
		}

		[Button]
		public void Save()
		{
			foreach (var saveLoader in _saveLoaders)
			{
				saveLoader.SaveGame(_repository, _diContainer);
			}

			_repository.SaveState();

#if UNITY_EDITOR
			Debug.Log("State saved by SaveLoadManager");
#endif
		}

		public void SaveSpecific<T>() where T : ISaveLoader
		{
			var saveLoaders = _saveLoaders.OfType<T>();
			foreach (var saveLoader in saveLoaders)
			{
				saveLoader.SaveGame(_repository, _diContainer);
			}

			_repository.SaveState();
		}

		private void OnSceneChanged(Scene arg0, Scene arg1)
		{
			UpdateContainer();
		}

		private void UpdateContainer()
		{
			var sceneContext = Object.FindFirstObjectByType<SceneContext>();
			if (sceneContext != null)
			{
				_diContainer = sceneContext.Container;
			}
		}

		public void Dispose()
		{
			SceneManager.activeSceneChanged -= OnSceneChanged;
		}
	}
}