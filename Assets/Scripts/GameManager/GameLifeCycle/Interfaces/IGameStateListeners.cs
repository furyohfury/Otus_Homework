public interface IGameStateListener
{
    static event Action<IGameStateListener> OnRegister;
    void Register();
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