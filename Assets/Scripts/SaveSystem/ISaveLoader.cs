using Zenject;

namespace SaveLoadHomework
{
    public interface ISaveLoader
    {
        void LoadGame(IGameRepository repository, SceneContext context);

        void SaveGame(IGameRepository repository, SceneContext context);
    }
}