public class GameFinishState : IGameState
{
    private List<IGameFinishListener> _iGameFinishListeners;
    
    public void IGameState.HandleState()
    {
        foreach(var listener in _iGameFinishListeners)
        {
            listener.FinishGame();
        }
    }
}