using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] saveLoaders;
        private GameRepository repository;

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository) //todo redo with IGameRepository
        {
            this.saveLoaders = saveLoaders;
            this.repository = repository;
        }

        [Button]
        public void Load()
        {
            this.repository.LoadState();

            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.LoadGame(this.repository, context);
            }
        }

        [Button]
        public void Save()
        {
            SceneContext context = FindObjectOfType<SceneContext>();
            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.SaveGame(this.repository, context);
            }

            this.repository.SaveState();
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