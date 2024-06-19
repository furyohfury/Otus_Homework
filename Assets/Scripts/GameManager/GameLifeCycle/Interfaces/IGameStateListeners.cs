using System;

namespace ShootEmUp
{
    public interface IGameStateListener
    {
        public static event Action<IGameStateListener> OnRegister;
        public static void Register(IGameStateListener listener)
        {
            OnRegister?.Invoke(listener);
        }
    }

    public interface IGameStartListener : IGameStateListener
    {
        void StartGame();
    }
    public interface IGamePauseListener : IGameStateListener
    {
        void PauseGame();
    }
    public interface IGameResumeListener : IGameStateListener
    {
        void ResumeGame();
    }
    public interface IGameFinishListener : IGameStateListener
    {
        void FinishGame();
    }
}
