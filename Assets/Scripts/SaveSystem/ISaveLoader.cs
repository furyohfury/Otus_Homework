using Zenject;

namespace Lessons.Architecture.SaveLoad
{
    public interface ISaveLoader
    {
        void LoadGame(IGameRepository repository, SceneContext context);

        void SaveGame(IGameRepository repository, SceneContext context);
    }
}