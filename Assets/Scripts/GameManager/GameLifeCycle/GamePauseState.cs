public class GamePauseState : IGameState
{    
    public void IGameState.HandleState(IEnumerable<IGameStateListerner> listeners)
    {
        var resumeGameListeners = listeners.Where((l) => l is IGameResumeListener).ToArray();
        foreach(var listener in resumeGameListeners)
        {
            listener.PauseGame();
        }
    }
}