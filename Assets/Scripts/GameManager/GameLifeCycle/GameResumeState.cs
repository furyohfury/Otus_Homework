public class GameResumeState : IGameState
{
    private List<IGameResumeListener> _iGameResumeListeners;
    
    public void IGameState.HandleState()
    {
        foreach(var listener in _iGameResumeListeners)
        {
            listener.ResumeGame();
        }
    }
}