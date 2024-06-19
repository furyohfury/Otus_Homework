public class GameStartState : IGameState
{
    private List<IGameStartListener> _iGameStartListeners;
    
    public void IGameState.HandleState()
    {
        foreach(var listener in _iGameStartListeners)
        {
            listener.StartGame();
        }
    }
}