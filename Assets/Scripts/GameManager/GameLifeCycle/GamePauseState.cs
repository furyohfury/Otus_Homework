public class GamePauseState : IGameState
{
    private List<IGamePauseListener> _iGamePauseListeners;
    
    public void IGameState.HandleState()
    {
        foreach(var listener in _iGamePauseListeners)
        {
            listener.PauseGame();
        }
    }
}