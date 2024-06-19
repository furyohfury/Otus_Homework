public class GameFinishState : IGameState
{
    public void IGameState.HandleState(IEnumerable<IGameStateListerner> listeners)
    {
        var finishGameListeners = listeners.Where((l) => l is IGameFinishListener).ToArray();
        foreach(var listener in finishGameListeners)
        {
            listener.FinishGame();
        }
    }
}