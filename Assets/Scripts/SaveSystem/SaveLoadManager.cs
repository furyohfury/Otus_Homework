using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveLoadHomework
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        private GameRepository _repository;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository)
        {
            _saveLoaders = saveLoaders;
            _repository = repository;
        }

        [Button]
        public void Load()
        {
            _repository.LoadState();

            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_repository, context);
            }
        }

        [Button]
        public void Save()
        {
            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_repository, context);
            }

            _repository.SaveState();
        }
    }
}