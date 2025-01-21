using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SaveLoad
{
	public sealed class SaveLoadManager : MonoBehaviour
	{
		private ISaveLoader[] _saveLoaders;
		private IGameRepository _repository;
		private DiContainer _diContainer;

		[Inject]
		public void Construct(ISaveLoader[] saveLoaders, IGameRepository repository, DiContainer diContainer)
		{
			_saveLoaders = saveLoaders;
			_repository = repository;
			_diContainer = diContainer;
		}

		private void OnEnable()
		{
			SceneManager.activeSceneChanged += OnSceneChanged; // TODO unnes mb kak to pomenyat no vrode ne tak vajno. Tipa svoy singleton scene manager
		}

		private void Start()
		{
			UpdateContainer();
		}

		[Button]
		public void Load()
		{
			_repository.LoadState();

			foreach (var saveLoader in _saveLoaders)
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
		}

		private void OnSceneChanged(Scene arg0, Scene arg1)
		{
			UpdateContainer();
		}

		private void UpdateContainer()
		{
			var sceneContext = FindObjectOfType<SceneContext>();
			if (sceneContext != null)
			{
				_diContainer = sceneContext.Container;
			}
		}

		private void OnDisable()
		{
			SceneManager.activeSceneChanged -= OnSceneChanged;
		}
	}
}