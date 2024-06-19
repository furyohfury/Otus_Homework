public interface IGameStartListener
{
    void StartGame();
}
public interface IGamePauseListener
{
    void PauseGame();
}
public interface IGameResumeListener
{
    void ResumeGame();
}
public interface IGameFinishListener
{
    void FinishGame();
}