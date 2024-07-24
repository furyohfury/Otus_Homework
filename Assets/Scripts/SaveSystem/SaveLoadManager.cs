using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] _saveLoaders;
        private GameRepository _repository;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository) //todo redo with IGameRepository
        {
            this._saveLoaders = saveLoaders;
            this._repository = repository;
        }

        [Button]
        public void Load()
        {
            this._repository.LoadState();

            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in this._saveLoaders)
            {
                saveLoader.LoadGame(this._repository, context);
            }
        }

        [Button]
        public void Save()
        {
            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in this._saveLoaders)
            {
                saveLoader.SaveGame(this._repository, context);
            }

            this._repository.SaveState();
        }

        //private void OnApplicationFocus(bool hasFocus)
        //{
        //    if (!hasFocus)
        //    {
        //        this.Save();
        //    }
        //}

        //private void OnApplicationPause(bool pauseStatus)
        //{
        //    if (pauseStatus)
        //    {
        //        this.Save();
        //    }
        //}

        //private void OnApplicationQuit()
        //{
        //    this.Save();
        //}
    }
}