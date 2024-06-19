public class GameStartState : IGameState
{    
    public void IGameState.HandleState(IEnumerable<IGameStateListerner> listeners)
    {
        var startGameListeners = listeners.Where((l) => l is IGameStartListener).ToArray();
        foreach(var listener in listeners)
        {
            if (listener is IGameStartListener startListener)
            {
                startListener.StartGame();
            }
        }
    }
}